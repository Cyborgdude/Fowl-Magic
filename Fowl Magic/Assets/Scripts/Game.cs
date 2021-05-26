using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Game: MonoBehaviour
{
    public static Game Current;
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

    public GameData GData;

    private void Awake()
    {
        if (Current == null)
        {
            DontDestroyOnLoad(gameObject);
            Current = this;
            GData = new GameData(0, 0, 0, 0, 0, 0, false, false);
        }
        else if (Current != this)
        {
            Destroy(gameObject);
        }
    }



}
