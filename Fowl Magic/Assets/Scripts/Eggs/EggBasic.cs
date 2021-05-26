using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBasic : MonoBehaviour, ILoss
{
    //Sprites
    [Header("Egg Sprites")]
    [SerializeField]
    protected Sprite[] SpriteArray = new Sprite[4];

    //SFX
    [Header("SFX")]
    [SerializeField]
    protected AudioClip SFXPowerupSound;
    [SerializeField]
    protected AudioClip SFXCrackSound;
    [SerializeField]
    private AudioClip SFXCollide;

    //Managers
    [Header("Managers")]
    [SerializeField]
    protected GameObject Speaker;

    [Header("Particles")]
    //Particles
    [SerializeField]
    protected GameObject Debris1;
    [SerializeField]
    protected GameObject SmallDebris1;

    //LossState
    private bool LossState;

    [Header("Gameplay")]
    //Other Var
    [SerializeField]
    protected int TapsNeededForShatter;
    private int CurrentTaps;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        Speaker = GameObject.FindGameObjectWithTag("Speaker");
        LossState = false;
        CurrentTaps = 0;
        this.GetComponent<SpriteRenderer>().sprite = SpriteArray[CurrentTaps];

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void TapEgg()
    {    
        CurrentTaps = CurrentTaps + 1;


        if (CurrentTaps >= TapsNeededForShatter)
        {
            SmashEgg();
        }
        else
        {
            Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(SFXCrackSound, SoundType.MinorSFX, 1.0f);
            SpawnThenDestroyParticle(SmallDebris1, gameObject.transform);
            this.GetComponent<SpriteRenderer>().sprite = SpriteArray[CurrentTaps];
        }


    }

    protected virtual void SmashEgg()
    {

        Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(SFXPowerupSound, SoundType.MajorSFX, 0.5f);
        SpawnThenDestroyParticle(Debris1, gameObject.transform);
        int RandomShellAdd = Random.Range(1, 4);
        Game.Current.GData.EggCount = Game.Current.GData.EggCount + RandomShellAdd;
        Destroy(gameObject);
    }

    protected void SpawnThenDestroyParticle(GameObject ParticleObject, Transform SpawnTransform)
    {
        GameObject ParticleObjectSpawned = Instantiate(ParticleObject, new Vector2(SpawnTransform.position.x, SpawnTransform.position.y), SpawnTransform.rotation);
        float ParticleObjectSpawnedDuration = ParticleObjectSpawned.GetComponent<ParticleSystem>().main.duration + ParticleObjectSpawned.GetComponent<ParticleSystem>().main.startLifetimeMultiplier;
        Destroy(ParticleObjectSpawned, ParticleObjectSpawnedDuration);
    }

    public void ILoss()
    {
        LossState = true;
    }

    private void OnMouseDown()
    {
        if (LossState !=true)
        {
            //AddRandomVelocity(gameObject);
            TapEgg();
        }
    }

    private void OnCollisionEnter2D(Collision2D Collision)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (Collision.relativeVelocity.magnitude >= 9)
        {
            rb.velocity = rb.velocity/4;
            TapEgg();
        }
        else if (Collision.relativeVelocity.magnitude >= 4)
        {
            Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(SFXCollide, SoundType.MinorSFX, (Collision.relativeVelocity.magnitude / 10));
        }
    }

    protected void AddRandomVelocity(GameObject ObjectToBeMoved)
    {
        //Add random velocity
        Rigidbody2D rb = ObjectToBeMoved.GetComponent<Rigidbody2D>();
        Vector2 RandomVelocity = new Vector2(Random.Range(-500.0f, 500.0f), Random.Range(350.0f, 500.0f));
        rb.AddForce(RandomVelocity);
    }
}
