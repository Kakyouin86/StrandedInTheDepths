using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    [Header("Info")]
    public float current = 10f;

    [Header("Settings")]
    public float max = 10f;
    public float burnRate = 1f;

    void Update()
    {
        if (Movement.instance.isMoving == true)
        {
            current -= burnRate * Time.deltaTime;
        }
        if (current <= 0f)
        {       // Show Ad
            Movement.instance.canMove = false;
            Movement.instance.gameObject.GetComponent<Rigidbody>().mass = 10;
            Movement.instance.gameObject.GetComponent<Rigidbody>().drag = 0;
        }
    }

    public void Refuel()
    {
        current = max;
    }

    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "Fuel")
        {
            Debug.Log("Fuel refill");
            current = max;
        }
    }
}

