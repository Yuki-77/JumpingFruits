using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    public Text highScoreText;
    public Text[] highScoreTexts;
    string highScoreKey = "HighScore";
    string[] highScoreKeys = {"hs1", "hs2", "hs3", "hs4" , "hs5"};
    

    void Start()
    {
        int hs;
        //Get the highScore from player prefs if it is there, 0 otherwise. 
        int highScore = PlayerPrefs.GetInt(highScoreKey, 0);

        for(int i = 0; i < 5; i++)
        {
            hs = PlayerPrefs.GetInt(highScoreKeys[i], 0);
            highScoreTexts[i].text = (i+1) + ". " + hs;
        }



        if(name == "TextYourScore")
        {
            ScoreText.text = "YOUR SCORE : " +GameManager.GetInstance().currentScore;
        }
        else
        {
            ScoreText.text = "";
        }
    }

    void Update()
    {
        int highScore = PlayerPrefs.GetInt(highScoreKey, 0);

        if(GameManager.GetInstance().currentScore >= highScore)
        {
            highScore = GameManager.GetInstance().currentScore;
        }
        highScoreText.text = "HIGH SCORE : " + highScore;
        if (name == "GameOverCanvas")
        {
            ScoreText.text = "YOUR SCORE : " + GameManager.GetInstance().currentScore;
        }
        else
        {
            ScoreText.text = "" + GameManager.GetInstance().currentScore;
        }
    }


    void OnDisable()
    {
        //for (int i = 0; i < 5; i++)
        int i = 0;
        while(i < 5)
        {
            if (GameManager.GetInstance().currentScore > PlayerPrefs.GetInt(highScoreKeys[i], 0))
            {
                for (int x = 4; x > i; x--)
                {
                    PlayerPrefs.SetInt(highScoreKeys[x], PlayerPrefs.GetInt(highScoreKeys[x - 1], 0));
                }
                PlayerPrefs.SetInt(highScoreKey, GameManager.GetInstance().currentScore);
                PlayerPrefs.SetInt(highScoreKeys[i], GameManager.GetInstance().currentScore);
                PlayerPrefs.Save();
                i = 10;
            }
            i++;
        }



        /*
        //set score as high score if score >= highScore
        if (GameManager.GetInstance().currentScore >= PlayerPrefs.GetInt(highScoreKey, 0))
        {
            PlayerPrefs.SetInt(highScoreKey, GameManager.GetInstance().currentScore);
            PlayerPrefs.Save();
        }
        */
    }
}
