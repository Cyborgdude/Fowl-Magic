using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointTracker : MonoBehaviour, IPointUpdate, ILoss {


    private int TotalPoints = 0;
    private int PointMulti = 1;
    private Text ScoreText;
    private Color BaseColor;
    private float MultiCountdown = 0;

    private GameObject HighScoreDisplay;

	// Use this for initialization
	void Start () {

        HighScoreDisplay = GameObject.FindGameObjectWithTag("HighScore");
        ScoreText = GetComponent<Text>();
        ScoreText.text = TotalPoints.ToString();
        BaseColor = ScoreText.color;
        SaveLoad.Load();
    }
	
	// Update is called once per frame
	void Update () {
        ScoreText.text = TotalPoints.ToString();
        // Debug.Log(Game.Current.GData.HighScore);
        //Debug.Log(PointMulti);
        if (MultiCountdown > 0.0f)
        {
            MultiCountdown = MultiCountdown - Time.deltaTime;
        }
        else
        {
            MultiCountdown = 0.0f;
            PointMulti = 1;
            ScoreText.color = BaseColor;
        }
    }

    public void IAddPoints(int PointsAmount)
    {
        TotalPoints = TotalPoints + (PointsAmount*PointMulti);    
    }

    public int IGetPoints()
    {
        return TotalPoints;
    }

    public void ISetPoints(int PointsAmount)
    {
        TotalPoints = PointsAmount;
    }

    public void ISetPointMulti(int MultiAmount, int Duration)
    {
        PointMulti = MultiAmount;
        MultiCountdown = Duration;
        ScoreText.color = new Color(187f/255f,26f/255f,47f/255f);
    }

    public void ILoss()
    {
        HighScoreDisplay.GetComponent<HighScore>().UpdateHighScore(TotalPoints, Game.Current.GData.HighScore);

        if(Game.Current.GData.HighScore < TotalPoints)
        {
            Game.Current.GData.HighScore = TotalPoints;
           
        }

        SaveLoad.Save();

    }

    
}
