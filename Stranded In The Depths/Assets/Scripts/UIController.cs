using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public Text levelText;
    public Image fadeScreen;
    public float fadeSpeed = 1.5f;
    public bool shouldFadeToBlack, shouldFadeFromBlack;
    public GameObject levelCompleteText;
    public Text timeInLevelText;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateLevelCount();
        FadeFromBlack();
    }


    void Update()
    {
        if (shouldFadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a > 0.9f)
            {
                shouldFadeToBlack = false;
            }
    }

        if (shouldFadeFromBlack)
        {
          fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
          if (fadeScreen.color.a  < 0.1f)
            {
                shouldFadeFromBlack = false;
            }
        }
    }


    public void UpdateLevelCount()
    {
        levelText.text = SceneManager.GetActiveScene().name;
        //converts the numbers into strings.
    }

    public void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }

     public void FadeFromBlack()
    {
        shouldFadeFromBlack = true;
        shouldFadeToBlack = false;
    }
}
