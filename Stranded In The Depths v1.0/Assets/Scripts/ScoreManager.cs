using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static int score;

    public static int highscore;

    Text text;

    void Start()
    {
        Timer.instance.timeInLevel = score;
        text = GetComponent<Text>();

        score = 0;

        highscore = PlayerPrefs.GetInt("highscore", highscore);
        text.text = highscore.ToString();
    }

    void Update()
    {
        if (score > highscore)
        {
            highscore = score;
            text.text = "" + score;

            PlayerPrefs.SetInt("highscore", highscore);
        }
    }

    public static void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
    }

    public static void Reset()
    {
        score = 0;
    }
}