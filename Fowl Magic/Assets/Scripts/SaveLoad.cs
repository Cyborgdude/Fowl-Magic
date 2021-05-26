using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad
{
    public static void Test()
    {
        Debug.Log("Test Successfull");
    }
    

    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Create(Application.persistentDataPath + "/GameSaves.sav");

        GameData GData = new GameData(Game.Current.GData.HighScore, Game.Current.GData.EggCount, Game.Current.GData.MusicMulti, Game.Current.GData.MajorSFXMulti, Game.Current.GData.MinorSFXMulti, Game.Current.GData.VoiceMulti, Game.Current.GData.TutPlayed, Game.Current.GData.FarmUIUnlocked);

        bf.Serialize(file, GData);
        file.Close();
    }

    public static void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/GameSaves.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream file = File.Open(Application.persistentDataPath + "/GameSaves.sav", FileMode.Open);

            GameData GData = (GameData)bf.Deserialize(file);

            Game.Current.GData = GData;
            file.Close();
        }
    }

}
