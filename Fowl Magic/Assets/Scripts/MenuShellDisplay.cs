using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuShellDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Text HighScoreText = GetComponent<Text>();
        HighScoreText.text = ("Shells: " + Game.Current.GData.EggCount.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
