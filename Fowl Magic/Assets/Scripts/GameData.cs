using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData
{
    [SerializeField]
    public int HighScore;
    [SerializeField]
    public int EggCount;
    [SerializeField]
    public float MusicMulti;
    [SerializeField]
    public float MajorSFXMulti;
    [SerializeField]
    public float MinorSFXMulti;
    [SerializeField]
    public float VoiceMulti;
    [SerializeField]
    public bool TutPlayed;
    [SerializeField]
    public bool FarmUIUnlocked;


    public GameData(int HScore, int ECount, float MusicM, float MajorSFXM, float MinorSFXM, float VoiceM, bool TPlayed, bool FUIUnlocked)
    {
        HighScore = HScore;
        EggCount = ECount;
        MusicMulti = MusicM;
        MajorSFXMulti = MajorSFXM;
        MinorSFXMulti = MinorSFXM;
        VoiceMulti = VoiceM;
        TutPlayed = TPlayed;
        FarmUIUnlocked = FUIUnlocked;
    }

}
