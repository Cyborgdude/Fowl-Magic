using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyVolume : MonoBehaviour
{
    [SerializeField]
    private GameObject Speaker;
    [SerializeField]
    private AudioClip TestSound;
    [SerializeField]
    private SoundType SoundTypeChanged;
    [SerializeField]
    private float ChangeAmount;


    // Start is called before the first frame update
    void Start()
    {
        Speaker = GameObject.FindGameObjectWithTag("Speaker");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeVolume()
    {
        int MaxVolume = 500;
        switch(SoundTypeChanged)
        {
            case SoundType.Music:
                //DOES NOT FUNCTION AS CHANGING MUSIC CHANGES MASTER VOLUME UNLESS PLAYED WITHOUT LOOP
                Game.Current.GData.MusicMulti = Game.Current.GData.MusicMulti + ChangeAmount;
                if(Game.Current.GData.MusicMulti > 100)
                {
                    Game.Current.GData.MusicMulti = 100;
                }
                if (Game.Current.GData.MusicMulti < 0f)
                {
                    Game.Current.GData.MusicMulti = 0f;
                }
                break;
            case SoundType.MajorSFX:
                Game.Current.GData.MajorSFXMulti = Game.Current.GData.MajorSFXMulti + ChangeAmount;
                if (Game.Current.GData.MajorSFXMulti > MaxVolume)
                {
                    Game.Current.GData.MajorSFXMulti = MaxVolume;
                }
                if (Game.Current.GData.MajorSFXMulti < 0f)
                {
                    Game.Current.GData.MajorSFXMulti = 0f;
                }
                break;
            case SoundType.MinorSFX:
                Game.Current.GData.MinorSFXMulti = Game.Current.GData.MinorSFXMulti + ChangeAmount;
                if (Game.Current.GData.MinorSFXMulti > MaxVolume)
                {
                    Game.Current.GData.MinorSFXMulti = MaxVolume;
                }
                if (Game.Current.GData.MinorSFXMulti < 0f)
                {
                    Game.Current.GData.MinorSFXMulti = 0f;
                }
                break;
            case SoundType.Voice:
                Game.Current.GData.VoiceMulti = Game.Current.GData.VoiceMulti + ChangeAmount;
                if (Game.Current.GData.VoiceMulti > MaxVolume)
                {
                    Game.Current.GData.VoiceMulti = MaxVolume;
                }
                if (Game.Current.GData.VoiceMulti < 0f)
                {
                    Game.Current.GData.VoiceMulti = 0f;
                }
                break;
        }


        SaveLoad.Save();
        Speaker.GetComponent<Speaker>().UpdateVolumeSettings();
        Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(TestSound, SoundTypeChanged, 1);
    }


}
