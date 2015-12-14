using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    public float scoreCount;
    public float highScoreCount;
    public float ptsPerSec;
    public bool scoreInc;

    void Start()
    {
        if(PlayerPrefs.GetFloat("HighScore") != 0)
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
    }//start

    void Update()
    {
        if (scoreInc)
        {
            scoreCount += ptsPerSec * Time.deltaTime;

            if (scoreCount > highScoreCount)
            {
                highScoreCount = scoreCount;
                PlayerPrefs.SetFloat("HighScore", highScoreCount);
            }//set the high score
        }

        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        highScoreText.text = "High Score: " + Mathf.Round(highScoreCount);
    }//update

    public void AddPoints(int points)
    {
        scoreCount += points;
    }//give score
}//class