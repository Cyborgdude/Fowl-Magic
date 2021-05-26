using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LossArea : MonoBehaviour
{
    private int ContainCount = 0;
    [SerializeField]
    private float StartingLossCountdown = 5;
    [SerializeField]
    private GameObject RedFlashParticle;
    [SerializeField]
    private AudioClip LosingSound;
    [SerializeField]
    private AudioClip LossSound;
    private float LossCountdown;
    private List<ILoss> LossObjects = new List<ILoss>();
    private GameObject SceneChangeManager;
    private GameObject Speaker;
    private bool GameOver;
    private bool LossT1Played = false;
    private bool LossT2Played = false;
    private bool LossT3Played = false;


    // Start is called before the first frame update
    void Start()
    {
        SceneChangeManager = GameObject.FindGameObjectWithTag("SceneChangeManager");
        Speaker = GameObject.FindGameObjectWithTag("Speaker");
        LossCountdown = StartingLossCountdown;
        GameOver = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(ContainCount > 0)
        {
            LossCountdown = LossCountdown - Time.deltaTime;
        }
        else
        {
            LossCountdown = StartingLossCountdown;
            LossT1Played = false;
            LossT2Played = false;
            LossT3Played = false;
        }

        if(LossCountdown <= 0)
        {
            if (GameOver == false)
            {
                //Call End Game
                SpawnThenDestroyParticleAtCentre(RedFlashParticle);

                Speaker.GetComponent<Speaker>().StopMusic();
                Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(LossSound, SoundType.MajorSFX, 2f);
                Loss();
            }


        }


        
        else if (LossCountdown <= (StartingLossCountdown/1.5) && LossT1Played == false)
        {
            SpawnThenDestroyParticleAtCentre(RedFlashParticle);
            Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(LosingSound, SoundType.MajorSFX, 1f);
            LossT1Played = true;

        }
        else if (LossCountdown <= (StartingLossCountdown / 3) && LossT2Played == false)
        {
            SpawnThenDestroyParticleAtCentre(RedFlashParticle);
            Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(LosingSound, SoundType.MajorSFX, 2f);
            LossT2Played = true;

        }
        else if (LossCountdown <= (StartingLossCountdown / 6) && LossT3Played == false)
        {
            SpawnThenDestroyParticleAtCentre(RedFlashParticle);
            Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(LosingSound, SoundType.MajorSFX, 4f);
            LossT3Played = true;

        }



    }

    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if(Collision.tag == "Orb" || Collision.tag == "Egg")
        {
            ContainCount = ContainCount + 1;
        }

        


    }

    private void OnTriggerExit2D(Collider2D Collision)
    {
        if(Collision.tag == "Orb" || Collision.tag == "Egg")
        {
            ContainCount = ContainCount - 1;
        }

        
    }

    private void Loss()
    {
        Debug.Log("GAME OVER");
        GameOver = true;


        //Notifies Objects of game loss, makes orbs unclickable, stops spawner etc
        LossObjects.AddRange(FindObjectsOfType<MonoBehaviour>().OfType<ILoss>().ToList());

        /*
        LossObjects.AddRange(FindObjectsOfType<Orb>().ToList());
        LossObjects.AddRange(FindObjectsOfType<PointTracker>().ToList());
        LossObjects.AddRange(FindObjectsOfType<Spawner>().ToList());
        */

        foreach (ILoss loss in LossObjects)
        {
            loss.ILoss();
        }

        Invoke("QuitToMenu", 10);
    }

    private void QuitToMenu()
    {
        SceneChangeManager.GetComponent<SceneChangeManager>().ChangeScene(GameScene.MenuScreen);
    }

    private void SpawnThenDestroyParticleAtCentre(GameObject ParticleObject)
    {
        GameObject ParticleObjectSpawned = Instantiate(ParticleObject, new Vector2(0, 0), Quaternion.identity);
        float ParticleObjectSpawnedDuration = ParticleObjectSpawned.GetComponent<ParticleSystem>().main.duration + ParticleObjectSpawned.GetComponent<ParticleSystem>().main.startLifetimeMultiplier;
        Destroy(ParticleObjectSpawned, ParticleObjectSpawnedDuration);
    }






}
