using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour
{
    public static SceneMan instance;
    public string levelText;
    public string levelToLoad;

    private void Awake()
    {

        instance = this;

    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void EndLevel()
    {
        StartCoroutine(EndLevelCo());
    }

    public IEnumerator EndLevelCo()
    {
        //AudioManager.instance.PlayLevelVictory();
        //PlayerController.instance.stopInput = true;
        //CameraController.instance.stopFollow = true;
        UIController.instance.levelCompleteText.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        UIController.instance.FadeToBlack();
        //If I don't put any yield, then I won't be able to test anything.
        yield return new WaitForSeconds((2.0f / UIController.instance.fadeSpeed) + 3f);
        //We will store information: PlayerPrefs. Unlocked is 1.
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_unlocked", 1);
        PlayerPrefs.SetString("CurrentLevel", (SceneManager.GetActiveScene().name));

        SceneManager.LoadScene(levelToLoad);
    }

    public void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        GetComponent<Movement>().enabled = true;
    }

    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;



        // check..
        string lname = SceneManager.GetActiveScene().name;

            int nextSceneIndex = currentSceneIndex + 1;
            if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
        }
    }
