using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyPrefs : MonoBehaviour

{
    public static DestroyPrefs instance;
    public GameObject[] other;
    public bool alreadyThere = false;
    public void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        PlayerPrefs.DeleteAll();

        if (GameObject.FindGameObjectsWithTag("PlayerPrefs").Length > 1)
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            alreadyThere = true;
            Debug.Log("Already there");
            other = GameObject.FindGameObjectsWithTag("PlayerPrefs");
            Destroy(gameObject);
        }
    }

    public void RunDelete()
    {
        other = GameObject.FindGameObjectsWithTag("PlayerPrefs");
        Destroy(gameObject);
    }
}
