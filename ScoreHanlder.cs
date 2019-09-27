using UnityEngine;
using UnityEngine.UI;

public class ScoreHanlder : MonoBehaviour
{
    //Setting variables for score 
    public static int scoreValue = 0;
    public Text scoreText;
    public Text highScore;
    private void Start()
    {
        scoreValue = 0;
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString(); //Fetching score from playerprefs
    }
    private void Update()
    {
        //Passing score value to text
        if(scoreValue == 0)
        {
            GetComponent<Text>().enabled = false;
        }
        else
        {
            GetComponent<Text>().enabled = true;
            scoreText.text = scoreValue.ToString();
        }
        

        //Saving score and checking if current score is higher than past high score
        if (scoreValue > PlayerPrefs.GetInt("HighScore")) { 
        PlayerPrefs.SetInt("HighScore", scoreValue);
            highScore.text = scoreValue.ToString();
        }
    }
}
