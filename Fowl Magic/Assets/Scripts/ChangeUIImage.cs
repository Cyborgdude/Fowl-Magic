using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeUIImage : MonoBehaviour
{
    private GameObject SceneChangeManager;
    private Image UIImage;

    //Sprites
    [SerializeField]
    private Sprite NatureSprite;
    [SerializeField]
    private Sprite FarmSprite;


    // Start is called before the first frame update
    void Start()
    {
        UIImage = GetComponent<Image>();
        SceneChangeManager = GameObject.FindGameObjectWithTag("SceneChangeManager");
        UIStyles UIStyle = SceneChangeManager.GetComponent<SceneChangeManager>().GetUIStyle();

        switch(UIStyle)
        {
            case UIStyles.Nature:
                UIImage.sprite = NatureSprite;
                break;
            case UIStyles.Farm:
                UIImage.sprite = FarmSprite;
                break;
        }

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
