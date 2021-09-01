using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music05 : MonoBehaviour
{
    private AudioSource _audioSource;
    private GameObject[] other;
    private bool NotFirst = false;
    public static Music05 instance;

    private void Awake()
        {
            instance = this;
            other = GameObject.FindGameObjectsWithTag("Music05");

            foreach (GameObject oneOther in other)
            {
                if (oneOther.scene.buildIndex == -1)
                {
                    NotFirst = true;
                }
            }

        if (GameObject.FindGameObjectsWithTag("Music05").Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(transform.gameObject);
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayMusic()
        {
            if (_audioSource.isPlaying) return;
            _audioSource.Play();
        }

        public void StopMusic()
        {
            _audioSource.Stop();
        }

    public void Update()
    {
        if (SceneManager.GetActiveScene().name == "Credits")
        {
            Destroy(gameObject);
        }
        if (UIPause.instance.isPaused == true)
        {
            _audioSource.Pause();
        }
        else
        {
            _audioSource.UnPause();
        }

        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            other = GameObject.FindGameObjectsWithTag("Music05");
            Destroy(gameObject);
        }
    }
    public void RunDelete()
    {
        Destroy(gameObject);
    }
}
