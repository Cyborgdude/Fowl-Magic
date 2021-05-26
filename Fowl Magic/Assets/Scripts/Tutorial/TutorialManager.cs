using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    //Managers
    private GameObject Speaker;
    private GameObject SceneChangeManager;

    //Particles & Sound
    [SerializeField]
    private GameObject PixelaxteParticle;
    [SerializeField]
    private AudioClip SFXButtonProgress;
    [SerializeField]
    private AudioClip SFXButtonProgressUpbeat;
    [SerializeField]
    private AudioClip SFXButtonProgressChicken;

    //Prefabs
    [SerializeField]
    private GameObject OrbPrefab;

    [SerializeField]
    private GameObject EggPrefab;

    //Mistress
    [SerializeField]
    private GameObject MistressSprite;

    public enum SpriteType
    {
        Happy,
        Unhappy,
        Chicken
    }

    [SerializeField]
    private Sprite HappySprite;
    [SerializeField]
    private Sprite UnHappySprite;
    [SerializeField]
    private Sprite ChickenSprite;

    //Other
    private Text ScoreText;
    [SerializeField]
    private Vector2 SpawnPoint;
    [SerializeField]
    private GameObject ProgressButton;
    private bool ProgressButtonUsable;
    private int StepNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        Speaker = GameObject.FindGameObjectWithTag("Speaker");
        SceneChangeManager = GameObject.FindGameObjectWithTag("SceneChangeManager");
        ChangeMistressSprite(SpriteType.Unhappy);
        ChangeMistresSpirteAlpha(1f);
        ProgressButton.SetActive(true);
        ProgressButtonUsable = true;
        ScoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    public void ProgressTut(bool ButtonSender)
    {
        if(ButtonSender == true)
        {
            //Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(SFXButtonProgress, SoundType.MinorSFX, 1);
        }
        if(ButtonSender == true && ProgressButtonUsable == false)
        {
            
        }
        else
        {
            switch(StepNumber)
            {
                case 1:
                    ChangeMistressSprite(SpriteType.Happy);
                    ScoreText.text = "You must be the new apprentice. Well apprentice, elemental magic is very complex, so lets start simple.";
                    Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(SFXButtonProgress, SoundType.Voice, 1);

                    break;
                case 2:
                    ChangeMistressSprite(SpriteType.Unhappy);
                    ScoreText.text = "When the fire orb drops from the sky tap on it to select it and then tap it again to deselect it.";
                    ChangeMistresSpirteAlpha(0.4f);
                    SpawnOrb(Element.Fire);
                    Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(SFXButtonProgress, SoundType.Voice, 1);
                    break;
                case 3:
                    ScoreText.text = "Once you are happy with your results, begin practice on the combination of elements. When the water orb drops from the sky, select both orbs to combine them.";
                    ProgressButtonUsable = false;
                    ProgressButton.SetActive(false);
                    SpawnOrb(Element.Water);
                    Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(SFXButtonProgress, SoundType.Voice, 1);
                    break;
                case 4:
                    //Activated with combiner
                    ChangeMistressSprite(SpriteType.Happy);
                    ChangeMistresSpirteAlpha(1f);
                    ScoreText.text = "You are rather slow apprentice, but your performance was acceptable. Now we will practice creating more complex elements by combining two base elements.";
                    ProgressButtonUsable = true;
                    ProgressButton.SetActive(true);
                    Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(SFXButtonProgressUpbeat, SoundType.Voice, 1);
                    break;
                case 5:
                    ChangeMistressSprite(SpriteType.Unhappy);
                    ScoreText.text = "When the plant and water orbs drop from the sky combine them together to create a swamp element.";
                    ChangeMistresSpirteAlpha(0.4f);
                    ProgressButtonUsable = false;
                    ProgressButton.SetActive(false);
                    SpawnOrb(Element.Plant);
                    SpawnOrb(Element.Water);
                    Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(SFXButtonProgress, SoundType.Voice, 1);
                    break;
                case 6:
                    //Activated with combiner
                    ChangeMistressSprite(SpriteType.Happy);
                    ScoreText.text = "Your speed is improving, but your technique still needs work. You have, however, sufficiently pleased me so we will move on.";
                    ProgressButtonUsable = true;
                    ProgressButton.SetActive(true);
                    Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(SFXButtonProgressUpbeat, SoundType.Voice, 1);
                    break;
                case 7:
                    ChangeMistressSprite(SpriteType.Unhappy);
                    ScoreText.text = "We will now practice combining tier one and two elements. When the fire orb drops from the sky combine it with the swamp orb to combine them.";
                    ProgressButtonUsable = false;
                    ProgressButton.SetActive(false);
                    SpawnOrb(Element.Fire);
                    Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(SFXButtonProgress, SoundType.Voice, 1);
                    break;
                case 8:
                    //Activated with combiner
                    ChangeMistressSprite(SpriteType.Happy);
                    ChangeMistresSpirteAlpha(1f);
                    ScoreText.text = "Don't get too hasty now, remember I am your boss and we must take this slowly.";
                    ProgressButtonUsable = true;
                    ProgressButton.SetActive(true);
                    Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(SFXButtonProgressUpbeat, SoundType.Voice, 1);
                    break;
                case 9:
                    ChangeMistressSprite(SpriteType.Unhappy);
                    ScoreText.text = "This combination only worked as fire was not used in the creation of the swamp element. Adding too much of one element to a combination can have disastrous results.";
                    Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(SFXButtonProgress, SoundType.Voice, 1);
                    break;
                case 10:
                    ChangeMistresSpirteAlpha(0.4f);
                    ScoreText.text = "We will now practice creating the urban element via combining two tier two orbs.";
                    ProgressButtonUsable = false;
                    ProgressButton.SetActive(false);
                    SpawnOrb(Element.Swamp);
                    SpawnOrb(Element.Lava);
                    Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(SFXButtonProgress, SoundType.Voice, 1);
                    break;
                case 11:
                    //Activated with combiner
                    ChangeMistressSprite(SpriteType.Happy);
                    ScoreText.text = "You know I must say I am pleasantly surprised at your basic understanding of easy to grasp concepts.";
                    ProgressButtonUsable = true;
                    ProgressButton.SetActive(true);
                    Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(SFXButtonProgressUpbeat, SoundType.Voice, 1);
                    break;
                case 12:
                    ScoreText.text = "Go on and experiment apprentice, lets see what else you can do.";
                    ProgressButtonUsable = false;
                    ProgressButton.SetActive(false);
                    SpawnOrb(Element.Air);
                    Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(SFXButtonProgress, SoundType.Voice, 1);
                    break;
                case 13:
                    //Activated with combiner
                    ChangeMistresSpirteAlpha(1f);
                    SpawnThenDestroyParticle(PixelaxteParticle, MistressSprite.transform);
                    ChangeMistressSprite(SpriteType.Chicken);
                    ScoreText.text = "CLUCK! (YOU FOOL!)";
                    ProgressButtonUsable = true;
                    ProgressButton.SetActive(true);
                    break;
                case 14:
                    ScoreText.text = "I should have known this was a mistake from the moment you walked through the hentrance. I, the eggscellent mistress should not have to be subjected to such poppycock.";
                    Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(SFXButtonProgressChicken, SoundType.Voice, 1);
                    break;
                case 15:
                    ScoreText.text = "Well, considering you have reduced me to this form, I suppose you will have to turn me back as well.";
                    Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(SFXButtonProgressChicken, SoundType.Voice, 1);
                    break;
                case 16:
                    ScoreText.text = "When combining elements, two rules must be followed.";
                    Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(SFXButtonProgressChicken, SoundType.Voice, 1);
                    break;
                case 17:
                    ScoreText.text = "Rule one is to avoid adding too much of a singular element. An element cannot combine with itself or one of its base elements.";
                    Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(SFXButtonProgressChicken, SoundType.Voice, 1);
                    break;
                case 18:
                    ScoreText.text = "For example, if you use fire to make an element, don't then try to combine the result with fire yet again.";
                    Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(SFXButtonProgressChicken, SoundType.Voice, 1);
                    break;
                case 19:
                    ScoreText.text = "Rule two is to avoid combining elements with elements of vastly different complexity.";
                    Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(SFXButtonProgressChicken, SoundType.Voice, 1);
                    break;
                case 20:
                    ScoreText.text = "For example, combining the tier 3 urban, with the tier 1 air.";
                    Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(SFXButtonProgressChicken, SoundType.Voice, 1);
                    break;
                case 21:
                    ChangeMistresSpirteAlpha(0.4f);
                    ScoreText.text = "When you fail to follow these rules useless grey matter will be created.";
                    Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(SFXButtonProgressChicken, SoundType.Voice, 1);
                    break;
                case 22:
                    ScoreText.text = "Well, I will at least attempt to assist you in my new form. Try tapping on this *HUURRR*.";
                    Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(SFXButtonProgressChicken, SoundType.Voice, 1);
                    SpawnEgg();
                    break;
                case 23:
                    ScoreText.text = "Well, it seems I have at least some of my magical power still. If you see and egg fall from the sky break it for a powerup.";
                    Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(SFXButtonProgressChicken, SoundType.Voice, 1);
                    break;
                case 24:
                    ScoreText.text = "The question mark eggs will grant a random orb, the red arrow eggs will double score for a brief period and the blue swirly eggs will reroll all elements currently on the field.";
                    Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(SFXButtonProgressChicken, SoundType.Voice, 1);
                    break;
                case 25:
                    ChangeMistresSpirteAlpha(1f);
                    ScoreText.text = "One more thing. Avoid allowing elements to stay within the red zone for too long or else chaos will overthrow these lands.";
                    Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(SFXButtonProgressChicken, SoundType.Voice, 1);
                    break;
                case 26:
                    ScoreText.text = "Good cluck, you will need it.";
                    Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(SFXButtonProgressChicken, SoundType.Voice, 1);
                    break;
                case 27:
                    Game.Current.GData.TutPlayed = true;
                    SaveLoad.Save();
                    SceneChangeManager.GetComponent<SceneChangeManager>().ChangeScene(GameScene.GameplayScene);
                    break;
            }

            StepNumber = StepNumber + 1;

        }


    }

    private void ChangeMistressSprite(SpriteType Type)
    {
        switch(Type)
        {
            case SpriteType.Happy:
                MistressSprite.GetComponent<Image>().sprite = HappySprite;
                break;
            case SpriteType.Unhappy:
                MistressSprite.GetComponent<Image>().sprite = UnHappySprite;
                break;
            case SpriteType.Chicken:
                MistressSprite.GetComponent<Image>().sprite = ChickenSprite;
                break;
        }
    }

    private void ChangeMistresSpirteAlpha(float Amount)
    {
        var SpriteColor = MistressSprite.GetComponent<Image>().color;
        SpriteColor.a = Amount;
        MistressSprite.GetComponent<Image>().color = SpriteColor;
    }

    private void SpawnOrb(Element OrbElement)
    {
        GameObject SpawnedOrb = Instantiate(OrbPrefab,
            new Vector2(Random.Range(SpawnPoint.x - 1, SpawnPoint.x + 1), SpawnPoint.y),
            Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360)))
            );

        SpawnedOrb.GetComponent<Orb>().SetElement(OrbElement);
    }

    private void SpawnEgg()
    {
        GameObject SpawnedEgg = Instantiate(EggPrefab,
            new Vector2(Random.Range(SpawnPoint.x - 1, SpawnPoint.x + 1), SpawnPoint.y),
            Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360)))
            );
    }

    private void SpawnThenDestroyParticle(GameObject ParticleObject, Transform SpawnTransform)
    {
        GameObject ParticleObjectSpawned = Instantiate(ParticleObject, new Vector2(SpawnTransform.position.x, SpawnTransform.position.y), SpawnTransform.rotation);
        float ParticleObjectSpawnedDuration = ParticleObjectSpawned.GetComponent<ParticleSystem>().main.duration + ParticleObjectSpawned.GetComponent<ParticleSystem>().main.startLifetimeMultiplier;
        Destroy(ParticleObjectSpawned, ParticleObjectSpawnedDuration);
    }
}
