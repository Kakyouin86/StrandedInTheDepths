using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatDisableCollisions : MonoBehaviour
{
    private string[] cheatCodeDisableCollisions;
    private int indexDisableCollisions;
    
    void Start()
    {
        // Code is "idkfa", user needs to input this in the right order
        cheatCodeDisableCollisions = new string[] { "i", "d", "d", "q", "d" };
        indexDisableCollisions = 0;
    }

    void Update()
    {
        // Check if any key is pressed
        if (Input.anyKeyDown)
        {
            // Check if the next key in the code is pressed
            if (Input.GetKeyDown(cheatCodeDisableCollisions[indexDisableCollisions]))
            {
                // Add 1 to index to check the next key in the code
                indexDisableCollisions ++;
            }
            // Wrong key entered, we reset code typing
            else
            {
                indexDisableCollisions = 0;
            }
        }

        // If index reaches the length of the cheatCode string, 
        // the entire code was correctly entered
        if (indexDisableCollisions == cheatCodeDisableCollisions.Length)
        {
            // Cheat code successfully inputted!
            // Unlock crazy cheat code stuff
            Debug.Log("Cheat works: disabling collisions");
            indexDisableCollisions = 0;
            GetComponent<CollisionHandler>().Invoke("RespondToDebugKeys", 0f);

        }
    }
}
