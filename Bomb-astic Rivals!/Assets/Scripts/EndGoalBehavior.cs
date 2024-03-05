using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoalBehavior : MonoBehaviour
{
    public Canvas endGameCanvas;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player reached the end goal!");
            
            // stop time
            Time.timeScale = 0;

            if(endGameCanvas)
            {
                // display end game canvas
                endGameCanvas.enabled = true;
            }
        }
    }
}
