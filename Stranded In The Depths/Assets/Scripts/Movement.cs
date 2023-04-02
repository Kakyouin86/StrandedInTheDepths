using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // PARAMETERS - for tuning, typically set in the editor
    // CACHE - e.g. references for readability or speed
    // STATE - private instance (member) variables

    GameObject theShip;
    Rigidbody rb;
    AudioSource audioSource;

    public float mainThrust = 1000f;
    public float rotationThrust = 200f;
    public AudioClip mainEngine;
    public ParticleSystem mainEngineParticles;
    public ParticleSystem leftThrusterParticles;
    public ParticleSystem rightThrusterParticles;

    public bool canMove;
    public bool isMoving;

    public static Movement instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        canMove = true;
        isMoving = false;
    }


    void Update()
    {
        ProcessThrust(); 
        ProcessRotation();
    }

   public void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (canMove)
            {
                StartThrusting();
            }
        }

        else
        {
            StopThrusting();
        }
    }


    public void StartThrusting()
    {
        if (!UIPause.instance.isPaused)
        {
            isMoving = true;
            Debug.Log("Is moving");
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }

            if (!mainEngineParticles.isPlaying)
            {
                mainEngineParticles.Play();
            }
        }
    }

    public void StopThrusting()
    {
        isMoving = false;
        Debug.Log("Is not moving");
        audioSource.Stop();
        mainEngineParticles.Stop();
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotation();
        }
    }

    private void RotateLeft()
    {
        ApplyRotation(rotationThrust);
        if (!rightThrusterParticles.isPlaying)
        {
            rightThrusterParticles.Play();
        }
    }

    private void RotateRight()
    {
        ApplyRotation(-rotationThrust);
        if (!leftThrusterParticles.isPlaying)
        {
            leftThrusterParticles.Play();
        }
    }

    private void StopRotation()
    {
        rightThrusterParticles.Stop();
        leftThrusterParticles.Stop();
    }

    public void ApplyRotation(float rotationThisFrame)

    {
        rb.freezeRotation = true;
        //freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        //(0,0,1)
        rb.freezeRotation = false;
        //umfreezing rotation so physics systems can take over
    }
}
