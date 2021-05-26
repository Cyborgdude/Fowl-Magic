using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockEquipUI : MonoBehaviour
{
    private GameObject SceneChangeManager;
    private GameObject Speaker;
    private int EasyUnlockCost = 100;
    private int MedUnlockCost = 500;
    private int HardUnlockCost = 1000;

    [SerializeField]
    private AudioClip EquipNoise;
    [SerializeField]
    private AudioClip FailureNoise;
    [SerializeField]
    private AudioClip UnlockNoise;

    [SerializeField]
    private GameObject EquipParticle;
    [SerializeField]
    private GameObject UnlockParticle;

    // Start is called before the first frame update
    void Start()
    {
        SceneChangeManager = GameObject.FindGameObjectWithTag("SceneChangeManager");
        Speaker = GameObject.FindGameObjectWithTag("Speaker");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnlockEquip(int UINumber)
    {
        UIStyles UIStyle = (UIStyles)UINumber;

        switch (UIStyle)
        {
            case UIStyles.Farm:
                if(Game.Current.GData.FarmUIUnlocked)
                {
                    PlayEquip(UIStyle);
                }
                else if(Game.Current.GData.EggCount >= EasyUnlockCost)
                {
                    Game.Current.GData.FarmUIUnlocked = true;
                    Game.Current.GData.EggCount = (Game.Current.GData.EggCount - EasyUnlockCost);
                    PlayUnlock();
                    PlayEquip(UIStyle);
                    SaveLoad.Save();
                }
                else
                {
                    //Not Enough Shells
                    PlayFail();
                }
                
                break;

            case UIStyles.Nature:
                PlayEquip(UIStyle);
                break;
                
        }


    }

    private void PlayEquip(UIStyles UIStyle)
    {
        SceneChangeManager.GetComponent<SceneChangeManager>().ChangeUIStyle(UIStyle);
        Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(EquipNoise,SoundType.MinorSFX,1);
        SpawnThenDestroyParticle(EquipParticle, transform);
    }

    private void PlayUnlock()
    {
        Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(UnlockNoise, SoundType.MinorSFX, 1);
        SpawnThenDestroyParticle(UnlockParticle, transform);
    }
    private void PlayFail()
    {
        Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(FailureNoise, SoundType.MinorSFX, 1);
    }

    private void SpawnThenDestroyParticle(GameObject ParticleObject, Transform SpawnTransform)
    {
        GameObject ParticleObjectSpawned = Instantiate(ParticleObject, new Vector2(SpawnTransform.position.x, SpawnTransform.position.y), SpawnTransform.rotation);
        float ParticleObjectSpawnedDuration = ParticleObjectSpawned.GetComponent<ParticleSystem>().main.duration + ParticleObjectSpawned.GetComponent<ParticleSystem>().main.startLifetimeMultiplier;
        Destroy(ParticleObjectSpawned, ParticleObjectSpawnedDuration);
    }
}
