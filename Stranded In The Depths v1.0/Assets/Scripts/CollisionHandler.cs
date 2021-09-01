using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float transitionLevelDelays = 2.0f;
    public AudioClip success;
    public AudioClip crash;
    public ParticleSystem successParticles;
    public ParticleSystem crashParticles;

    AudioSource audioSource;

    public bool isTransitioning = false;
    bool collisionDisable = false;

    //public float scoreLevel;
    public static CollisionHandler instance;

    public Text totalTime, scoreLevel01, scoreLevel02, scoreLevel03, scoreLevel04, scoreLevel05, scoreLevel06, scoreLevel07, scoreLevel08, scoreLevel09, scoreLevel10;
    public float oldScoreLevel01, oldScoreLevel02, oldScoreLevel03, oldScoreLevel04, oldScoreLevel05, oldScoreLevel06, oldScoreLevel07, oldScoreLevel08, oldScoreLevel09, oldScoreLevel10;
    public float actualScoreLevel02, actualScoreLevel03, actualScoreLevel04, actualScoreLevel05, actualScoreLevel06, actualScoreLevel07, actualScoreLevel08, actualScoreLevel09, actualScoreLevel10;
    public Text collisionsText;
    public float collisions;
    //Ernesto


    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        collisions = 0.0f;
        PlayerPrefLoadCrashes();
    }

    public void Update()
    {
        scoreLevel01.text = PlayerPrefs.GetFloat("Level 01", Timer.instance.timeInLevel).ToString("f2");
        oldScoreLevel01 = PlayerPrefs.GetFloat("Level 01", Timer.instance.timeInLevel);
        
        scoreLevel02.text = actualScoreLevel02.ToString("f2");
        oldScoreLevel02 = PlayerPrefs.GetFloat("Level 02", Timer.instance.timeInLevel);
        actualScoreLevel02 = oldScoreLevel02 - oldScoreLevel01;
        
        scoreLevel03.text = actualScoreLevel03.ToString("f2");
        oldScoreLevel03 = PlayerPrefs.GetFloat("Level 03", Timer.instance.timeInLevel);
        actualScoreLevel03 = oldScoreLevel03 - oldScoreLevel02;

        scoreLevel04.text = actualScoreLevel04.ToString("f2");
        oldScoreLevel04 = PlayerPrefs.GetFloat("Level 04", Timer.instance.timeInLevel);
        actualScoreLevel04 = oldScoreLevel04 - oldScoreLevel03;

        scoreLevel05.text = actualScoreLevel05.ToString("f2");
        oldScoreLevel05 = PlayerPrefs.GetFloat("Level 05", Timer.instance.timeInLevel);
        actualScoreLevel05 = oldScoreLevel05 - oldScoreLevel04;

        scoreLevel06.text = actualScoreLevel06.ToString("f2");
        oldScoreLevel06 = PlayerPrefs.GetFloat("Level 06", Timer.instance.timeInLevel);
        actualScoreLevel06 = oldScoreLevel06 - oldScoreLevel05;

        scoreLevel07.text = actualScoreLevel07.ToString("f2");
        oldScoreLevel07 = PlayerPrefs.GetFloat("Level 07", Timer.instance.timeInLevel);
        actualScoreLevel07 = oldScoreLevel07 - oldScoreLevel06;

        //scoreLevel08.text = actualScoreLevel08.ToString("f2");
        //oldScoreLevel08 = PlayerPrefs.GetFloat("Level 08", Timer.instance.timeInLevel);
        //actualScoreLevel08 = oldScoreLevel08 - oldScoreLevel07;

        //scoreLevel09.text = actualScoreLevel09.ToString("f2");
        //oldScoreLevel09 = PlayerPrefs.GetFloat("Level 09", Timer.instance.timeInLevel);
        //actualScoreLevel09 = oldScoreLevel09 - oldScoreLevel08;

        //scoreLevel10.text = actualScoreLevel10.ToString("f2");
        //oldScoreLevel10 = PlayerPrefs.GetFloat("Level 10", Timer.instance.timeInLevel);
        //actualScoreLevel10 = oldScoreLevel10 - oldScoreLevel09;

        totalTime.text = PlayerPrefs.GetFloat("Level 07", Timer.instance.timeInLevel).ToString("f2") + " total time";

        collisionsText.text = PlayerPrefs.GetFloat("crash", Timer.instance.timeInLevel).ToString("f0") + " deaths";

    }

    void RespondToDebugKeys()
    {
        collisionDisable = !collisionDisable;  // toggle collision
    }

        //SceneMan sm = new SceneMan();

        void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (isTransitioning || collisionDisable)
        {
            return;
        }

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This is the launching pad");
                break;
            case "Finish":
                Debug.Log("Finished!");
                StartFinishSequence();
                break;
            case "Fuel":
                Debug.Log("Fuel refill");
                break;
            default:
                Debug.Log("Crashed!");
                StartCrashSequence();
                break;
        }
    }

    public void StartCrashSequence()
    {
        isTransitioning = true;
        //stop camera here (new after Ernesto)


        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        crashParticles.Play();
        GetComponent<Movement>().enabled = false;
        GetComponent<SceneMan>().Invoke("ReloadLevel", transitionLevelDelays);
        collisions++;
    }

    public void StartFinishSequence()
    {
        isTransitioning = true;
        Timer.instance.stopTimer = true;

        if (SceneManager.GetActiveScene().name == "Level 01")
        {
            PlayerPrefs.SetFloat("Level 01", Timer.instance.timeInLevel);
        }
        if (SceneManager.GetActiveScene().name == "Level 02")
        {
            PlayerPrefs.SetFloat("Level 02", Timer.instance.timeInLevel);
        }
        if (SceneManager.GetActiveScene().name == "Level 03")
        {
            PlayerPrefs.SetFloat("Level 03", Timer.instance.timeInLevel);
        }
        if (SceneManager.GetActiveScene().name == "Level 04")
        {
            PlayerPrefs.SetFloat("Level 04", Timer.instance.timeInLevel);
        }
        if (SceneManager.GetActiveScene().name == "Level 05")
        {
            PlayerPrefs.SetFloat("Level 05", Timer.instance.timeInLevel);
        }
        if (SceneManager.GetActiveScene().name == "Level 06")
        {
            PlayerPrefs.SetFloat("Level 06", Timer.instance.timeInLevel);
        }
        if (SceneManager.GetActiveScene().name == "Level 07")
        {
            PlayerPrefs.SetFloat("Level 07", Timer.instance.timeInLevel);
        }
        //if (SceneManager.GetActiveScene().name == "Level 08")
        //{
        //    PlayerPrefs.SetFloat("Level 08", Timer.instance.timeInLevel);
        //}
        //if (SceneManager.GetActiveScene().name == "Level 09")
        //{
        //    PlayerPrefs.SetFloat("Level 09", Timer.instance.timeInLevel);
        //}
        //if (SceneManager.GetActiveScene().name == "Level 10")
        //{
        //    PlayerPrefs.SetFloat("Level 10", Timer.instance.timeInLevel);
        //}

        audioSource.Stop();
        audioSource.PlayOneShot(success);
        successParticles.Play();
        GetComponent<Movement>().enabled = false;
        UIController.instance.levelCompleteText.SetActive(true);
        GetComponent<SceneMan>().Invoke("LoadNextLevel", transitionLevelDelays);
    }

    public void PlayerPrefLoadCrashes()
    {
        if (PlayerPrefs.HasKey("crash")) collisions = PlayerPrefs.GetFloat("crash");
    }

    public void OnDestroy()
    {
        PlayerPrefs.SetFloat("crash", collisions);
    }
}


