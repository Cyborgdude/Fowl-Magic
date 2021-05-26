using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuScoreDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Text HighScoreText = GetComponent<Text>();
        HighScoreText.text = ("Record: " + Game.Current.GData.HighScore.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
