using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoalBehaviour2 : MonoBehaviour
{
    public GameObject endGameCanvas1;
    

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("endline"))
        {
            Debug.Log("Player reached the end goal!");
            
            // stop time
            

            if(endGameCanvas1)
            {
                // display end game canvas
                endGameCanvas1.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
        
    }
}
