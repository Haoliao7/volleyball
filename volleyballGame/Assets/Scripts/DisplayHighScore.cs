using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighScore : MonoBehaviour
{
    const string HIGH_SCORE = "highScore";//set the string to const so it won't change by anything

    private int highScore;
    public int HighScore
    {
        get
        {
            highScore = PlayerPrefs.GetInt(HIGH_SCORE, 0); //store the highscore into PlayerPrefs
            return highScore;
        }
        set
        {
            highScore = value; // set the highScore as the value
            PlayerPrefs.SetInt(HIGH_SCORE, highScore); // Change the highScore to the value

        }
    }



    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        
        if (HighScore < GameManager.highScore) // if the highScore now is greater than the highScore record
        {
            HighScore = GameManager.highScore; // then you are the highScore now

        }

        gameObject.GetComponent<Text>().text = ("High Score : " + HighScore.ToString()); //display the high score
    }
}
