using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChangeManager : MonoBehaviour
{
    private GameScene CurrentScene;
    private GameScene NewScene;
   
    [SerializeField]
    private AudioClip StartScreenMusic;
    [SerializeField]
    private AudioClip MenuScreenMusic;
    [SerializeField]
    private AudioClip GameplayMusic;

    [SerializeField]
    private GameObject Speaker;

    [SerializeField]
    private Animator FadeAnimator;

    [SerializeField]
    private UIStyles UISelected;

    // Start is called before the first frame update
    void Start()
    {
        //Screen.SetResolution(1920, 1080, true);
        CurrentScene = GameScene.StartScreen;
        DontDestroyOnLoad(gameObject);
        
        SaveLoad.Load();

        //Set Volume Multiplier Defaults when no save data is present
        if (Game.Current.GData.MusicMulti == 0)
        {
            Game.Current.GData.MusicMulti = 100;
        }
        if (Game.Current.GData.MajorSFXMulti == 0)
        {
            Game.Current.GData.MajorSFXMulti = 100;
        }
        if (Game.Current.GData.MinorSFXMulti == 0)
        {
            Game.Current.GData.MinorSFXMulti = 100;
        }
        if (Game.Current.GData.VoiceMulti == 0)
        {
            Game.Current.GData.VoiceMulti = 100;
        }

        SaveLoad.Save();
        Speaker = GameObject.FindGameObjectWithTag("Speaker");
        Speaker.GetComponent<Speaker>().UpdateVolumeSettings();
        Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(StartScreenMusic, SoundType.Music, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ChangeScene(GameScene SceneToLoad)
    {
        NewScene = SceneToLoad;
        FadeAnimator.SetTrigger("FadeOut");

        Invoke("LoadScene", 2);

    }

    private void LoadScene()
    {



        switch (NewScene)
        {
            case GameScene.MenuScreen:
                SceneManager.LoadScene("MenuScreen", LoadSceneMode.Single);
                CurrentScene = GameScene.MenuScreen;
                Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(MenuScreenMusic, SoundType.Music, 0.5f);

                break;
            case GameScene.GameplayScene:
                SceneManager.LoadScene("GameplayScene", LoadSceneMode.Single);
                CurrentScene = GameScene.GameplayScene;
                Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(GameplayMusic, SoundType.Music, 0.5f);
                break;
            case GameScene.OptionsScreen:
                SceneManager.LoadScene("OptionsScreen", LoadSceneMode.Single);
                CurrentScene = GameScene.OptionsScreen;
                Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(GameplayMusic, SoundType.Music, 0.5f);
                break;
            case GameScene.TutorialScene:
                SceneManager.LoadScene("TutorialScene", LoadSceneMode.Single);
                CurrentScene = GameScene.TutorialScene;
                Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(MenuScreenMusic, SoundType.Music, 0.5f);
                break;
        }


        FadeAnimator.SetTrigger("FadeIn");
    }

    public void ChangeUIStyle(UIStyles NewUIStyle)
    {
        UISelected = NewUIStyle;
    }

    public UIStyles GetUIStyle()
    {
        return UISelected;
    }


}

