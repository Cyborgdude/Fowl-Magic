using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour
{
    private AudioSource GlobalSource;

    //Volume Settings
    [SerializeField]
    private float MajorSFXMulti;
    [SerializeField]
    private float MinorSFXMulti;
    [SerializeField]
    private float MusicMulti;
    [SerializeField]
    private float VoiceMulti;

    AudioClip CurrentlyPlayingMusic;



    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        GlobalSource = GetComponent<AudioSource>();
        GlobalSource.loop = true;

    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySoundFromSpeaker(AudioClip Sound, SoundType SoundType, float Multi)
    {
        switch (SoundType)
        {
            case SoundType.MajorSFX:
                Multi = Multi * MajorSFXMulti;
                break;
            case SoundType.MinorSFX:
                Multi = Multi * MinorSFXMulti;
                break;
            case SoundType.Music:
                Multi = Multi * MusicMulti;
                break;
            case SoundType.Voice:
                Multi = Multi * VoiceMulti;
                break;
        }

        if(SoundType == SoundType.Music)
        {
            GlobalSource.Stop();
            GlobalSource.volume = Multi;
            GlobalSource.clip = Sound;
            GlobalSource.Play();
        }
        else
        {
            GlobalSource.PlayOneShot(Sound, Multi);
        }

    }

    public void UpdateVolumeSettings()
    {
        MajorSFXMulti = Game.Current.GData.MajorSFXMulti/100;
        MinorSFXMulti = Game.Current.GData.MinorSFXMulti/100;
        MusicMulti = Game.Current.GData.MusicMulti/100;
        VoiceMulti = Game.Current.GData.VoiceMulti/100;
    }

    public void StopMusic()
    {
        GlobalSource.Stop();
    }
}
