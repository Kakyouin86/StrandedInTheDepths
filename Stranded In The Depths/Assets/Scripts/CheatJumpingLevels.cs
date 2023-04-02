using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatJumpingLevels : MonoBehaviour
{
    private string[] cheatCodeJumpLevels;
    private int indexJumpLevels;

    void Start()
    {
        // Code is "idkfa", user needs to input this in the right order
        cheatCodeJumpLevels = new string[] { "i", "d", "k", "f", "a" };
        indexJumpLevels = 0;
    }

    void Update()
    {
        // Check if any key is pressed
        if (Input.anyKeyDown)
        {
            // Check if the next key in the code is pressed
            if (Input.GetKeyDown(cheatCodeJumpLevels[indexJumpLevels]))
            {
                // Add 1 to index to check the next key in the code
                indexJumpLevels ++;
            }
            // Wrong key entered, we reset code typing
            else
            {
                indexJumpLevels = 0;
            }
        }

        // If index reaches the length of the cheatCode string, 
        // the entire code was correctly entered
        if (indexJumpLevels == cheatCodeJumpLevels.Length)
        {
            // Cheat code successfully inputted!
            // Unlock crazy cheat code stuff
            Debug.Log("Cheat works: playing next level");
            indexJumpLevels = 0;
            GetComponent<SceneMan>().Invoke("LoadNextLevel", 2f);
        }
    }
}
