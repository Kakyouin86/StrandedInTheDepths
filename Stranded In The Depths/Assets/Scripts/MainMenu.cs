using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string startScene;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Music.instance != null)
        {
            Music.instance.RunDelete();
        }

        if (Music05.instance != null)
        {
            Music05.instance.RunDelete();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(startScene);
        PlayerPrefs.DeleteAll();
        if (Music.instance != null)
        {
            Music.instance.RunDelete();
        }

        if (Music05.instance != null)
        {
            Music05.instance.RunDelete();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game");
    }

}

