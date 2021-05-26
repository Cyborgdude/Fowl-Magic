using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    private GameObject SceneChangeManager;
    private GameScene GameScene;
    // Start is called before the first frame update
    void Start()
    {
        SceneChangeManager = GameObject.FindGameObjectWithTag("SceneChangeManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonSceneChange(int SceneEnumNumber)
    {
        if(Game.Current.GData.TutPlayed == false)
        {
            Debug.Log("Error");
            SceneEnumNumber = 5;
        }
        Button ButtonComp = GetComponent<Button>();
        ButtonComp.interactable = false;
        GameScene GameScene = (GameScene)SceneEnumNumber;
        Debug.Log(GameScene);

        SceneChangeManager.GetComponent<SceneChangeManager>().ChangeScene(GameScene);


    }
}
