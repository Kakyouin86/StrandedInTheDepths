using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeInLevel;
    public bool stopTimer = false;
    public static Timer instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        timeInLevel = 0.0f;
        PlayerPrefLoad();
        stopTimer = false;
    }

    void Update()
    {
        if (!stopTimer)
        {
            timeInLevel += Time.deltaTime;
            string minutes = ((int)timeInLevel / 60).ToString();
            string seconds = (timeInLevel % 60).ToString("f2");
            UIController.instance.timeInLevelText.text = minutes + ":" + seconds;
        }
    }

    public void PlayerPrefLoad()
    {
        if (PlayerPrefs.HasKey("score")) timeInLevel = PlayerPrefs.GetFloat("score");
    }

    public void OnDestroy()
    {
        PlayerPrefs.SetFloat("score", timeInLevel);
    }
}
