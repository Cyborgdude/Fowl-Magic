using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour, ILoss
{
    //LossState
    private bool LossState;

    [Header("Orb Properties")]
    [SerializeField]
    private Element OrbElement;
    private Tier OrbTier;

    [Header("Managers")]
    [SerializeField]
    private GameObject Combiner;
    [SerializeField]
    private GameObject Speaker;
    
    //Sprites

    //Tier 0
    [Header("Tier 0 Orbs Sprites")]
    [SerializeField]
    private Sprite GreyMatterSpirte;

    //Tier 1
    [Header("Tier 1 Orbs Sprites")]
    [SerializeField]
    private Sprite FireSprite;

    [SerializeField]
    private Sprite WaterSprite;

    [SerializeField]
    private Sprite AirSprite;

    [SerializeField]
    private Sprite PlantSprite;

    //Tier 2
    [Header("Tier 2 Orbs Sprites")]
    [SerializeField]
    private Sprite CinderSprite;

    [SerializeField]
    private Sprite LavaSprite;

    [SerializeField]
    private Sprite RainSprite;

    [SerializeField]
    private Sprite SwampSprite;

    //Tier 3
    [Header("Tier 3 Orbs Sprites")]
    [SerializeField]
    private Sprite MysticSprite;

    [SerializeField]
    private Sprite SparkSprite;

    [SerializeField]
    private Sprite ObsidianSprite;

    [SerializeField]
    private Sprite UrbanSprite;

    //Tier 4
    [Header("Tier 4 Orbs Sprites")]
    [SerializeField]
    private Sprite EntropySprite;

    [SerializeField]
    private Sprite OrderSprite;

    //Sounds
    [Header("SFX")]
    [SerializeField]
    private AudioClip SFXSelect;
    [SerializeField]
    private AudioClip SFXError;
    [SerializeField]
    private AudioClip SFXCollide;

    //ParticleSystem
    private ParticleSystem GlowRing;

    [Header("Glow Ring")]
    [SerializeField]
    private Gradient Tier1LifeTimeGradient;
    [SerializeField]
    private Gradient Tier2LifeTimeGradient;
    [SerializeField]
    private Gradient Tier3LifeTimeGradient;
    [SerializeField]
    private Gradient Tier4LifeTimeGradient;

    //Other
    private bool Selected = false;


    // Use this for initialization
    void Start () {

        LossState = false;
        GlowRing = GetComponent<ParticleSystem>();
        Combiner = GameObject.FindGameObjectWithTag("Combiner");
        Speaker = GameObject.FindGameObjectWithTag("Speaker");
        ToggleParticle();
        ChangeElement();
	}
    
    //Allows other classes to set this objects element
    public void SetElement(Element NewElement)
    {
        OrbElement = NewElement;
        ChangeElement();
    }

    //Allows other classes to get this objects element
    public Element GetElement( )
    {
        return OrbElement;
    }

    //Allows other classes to get this objects tier
    public Tier GetTier()
    {
        return OrbTier;
    }

    //Change Element based on the objects element value
    private void ChangeElement()
    {
        //Create Local Variables
        Sprite ElementSprite = FireSprite;

        //Change Sprite Based on Element
        switch (OrbElement)
        {
            //Grey Matter Element
            case Element.GreyMatter:
                ElementSprite = GreyMatterSpirte;
                OrbTier = Tier.Tier0;
                break;

            //Tier 1
            //Fire Element
            case Element.Fire:
                ElementSprite = FireSprite;
                OrbTier = Tier.Tier1;
                break;
            //Water Element
            case Element.Water:
                ElementSprite = WaterSprite;
                OrbTier = Tier.Tier1;
                break;
            //Air Element
            case Element.Air:
                ElementSprite = AirSprite;
                OrbTier = Tier.Tier1;
                break;
            //Plant Element
            case Element.Plant:
                ElementSprite = PlantSprite;
                OrbTier = Tier.Tier1;
                break;

            //Tier 2
            //Cinder Element
            case Element.Cinder:
                ElementSprite = CinderSprite;
                OrbTier = Tier.Tier2;
                break;
            //Lava Element
            case Element.Lava:
                ElementSprite = LavaSprite;
                OrbTier = Tier.Tier2;
                break;
            //Rain Element
            case Element.Rain:
                ElementSprite = RainSprite;
                OrbTier = Tier.Tier2;
                break;
            //Swamp Element
            case Element.Swamp:
                ElementSprite = SwampSprite;
                OrbTier = Tier.Tier2;
                break;

            //Tier 3
            //Mystic Element
            case Element.Mystic:
                ElementSprite = MysticSprite;
                OrbTier = Tier.Tier3;
                break;
            //Spark Element
            case Element.Spark:
                ElementSprite = SparkSprite;
                OrbTier = Tier.Tier3;
                break;
            //Obsidian Element
            case Element.Obsidian:
                ElementSprite = ObsidianSprite;
                OrbTier = Tier.Tier3;
                break;
            //Urban Element
            case Element.Urban:
                ElementSprite = UrbanSprite;
                OrbTier = Tier.Tier3;
                break;

            //Tier 4
            //Entropy Element
            case Element.Entropy:
                ElementSprite = EntropySprite;
                OrbTier = Tier.Tier4;
                break;
            //Order Element
            case Element.Order:
                ElementSprite = OrderSprite;
                OrbTier = Tier.Tier4;
                break;
        }

        //Set Sprite
        this.GetComponent<SpriteRenderer>().sprite = ElementSprite;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ILoss()
    {
        LossState = true;
    }

    private void OnMouseDown()
    {
        print("Clicked");
        if (LossState != true)
        {
            if (OrbElement != Element.GreyMatter)
            {
                if (Combiner.GetComponentInChildren<Combiner>() != null)
                {
                    Combiner.GetComponentInChildren<Combiner>().Combine(OrbElement, OrbTier, gameObject);
                    Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(SFXSelect, SoundType.MinorSFX, 1.0f);
                    ToggleParticle();
                    Selected = !Selected;
                }
            }
            else
            {
                Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(SFXError, SoundType.MinorSFX, 1.0f);
            }
        }

    }

    private void ToggleParticle()
    {
        if(GlowRing.isPlaying)
        {
            GlowRing.Stop();
        }
        else
        {
            ChangeGlowRingTier();
            GlowRing.Play();
        }

        GlowRing.Clear();
        
        
    }

    private void OnCollisionEnter2D(Collision2D Collision)
    {
        if (Collision.relativeVelocity.magnitude >= 4)
        {
            Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(SFXCollide, SoundType.MinorSFX, (Collision.relativeVelocity.magnitude/10));
        }

    }

    private void ChangeGlowRingTier()
    {

        var Col = GlowRing.colorOverLifetime;

        switch (OrbTier)
        {
            
            //T1
            case Tier.Tier1:
                Col.color = Tier1LifeTimeGradient;
                break;
            //T2
            case Tier.Tier2:
                Col.color = Tier2LifeTimeGradient;
                break;
            //T3
            case Tier.Tier3:
                Col.color = Tier3LifeTimeGradient;
                break;
            //T4
            case Tier.Tier4:
                Col.color = Tier4LifeTimeGradient;
                break;
        }
    }

    public bool GetIFSelected()
    {
        return Selected;
    }
}
