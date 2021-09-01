using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{

    private string inputString;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            inputString += 'U';
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            inputString += 'L';
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            inputString += 'D';
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            inputString += 'R';
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            inputString += 'A';
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            inputString += 'B';
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            if (inputString.EndsWith("UUDDLRLRBA"))
            {
                Debug.Log("30");
            }
            else
            {
                Debug.Log("3");
            }
        }
    }
}