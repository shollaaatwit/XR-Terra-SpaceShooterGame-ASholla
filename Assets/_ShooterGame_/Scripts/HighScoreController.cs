using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreController : Singleton<HighScoreController>
{
    public long[] highscores = new long[10];

    public static Text highscoreOne;
    public static Text highscoreTwo;
    public static Text highscoreThree;
    public static Text highscoreFour;
    public static Text highscoreFive;
    public static Text highscoreSix;
    public static Text highscoreSeven;
    public static Text highscoreEight;
    public static Text highscoreNine;
    public static Text highscoreTen;

    public Text[] highscoreList = new Text[10]{highscoreOne, highscoreTwo, highscoreThree, highscoreFour, highscoreFive, highscoreSix, highscoreSeven, highscoreEight, highscoreNine, highscoreTen};


    public bool IsHighScore(long value)
    {
        return (value > highscores[0]);
    }

    public bool AddHighScore(long value)
    {
        if(!IsHighScore(value))
        {
            return false;
        }
        for(int i = 9; i > 0; i--)
        {
            highscores[i] = highscores[i-1];
        }
        highscores[0] = value;
        return true;
    }

    public void UpdateHighScoreList()
    {
        for(int i = 0; i < 9; i++)
        {
            highscoreList[i].text = "Score: " + highscores[i];
        }
    }
}
