using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHighScore(int NewScore, int OldScore)
    {
        Text HighScoreText = GetComponent<Text>();

        if (NewScore > OldScore)
        {
            HighScoreText.text = ("New High Score: "  + NewScore.ToString());
        }
        else
        {
            HighScoreText.text = ("High Score: " + OldScore.ToString());
        }
        

    }
        
}

