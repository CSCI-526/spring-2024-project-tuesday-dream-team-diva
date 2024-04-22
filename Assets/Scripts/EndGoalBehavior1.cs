using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoalBehavior1 : MonoBehaviour
{
    public GameObject endGameCanvas1;
    public EndGoalBehavior2 check;

    public bool reached = false;
    public GameObject nextLevels;

    void Start(){
        reached = false;
    }

    void Update() {
      if (check != null && check.reached)
    {
        nextLevels.SetActive(true);
        Time.timeScale = 0.0f;
    }

    }
    

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("endline1"))
        {
            Debug.Log("Player reached the end goal!");
            
            // stop time

            reached = true;

            if(endGameCanvas1)
            {
                // display end game canvas
                endGameCanvas1.SetActive(true);
                // Time.timeScale = 0.0f;

                if(MainManager.Instance != null)
                {
                    MainManager.Instance.UpdateGameProgress();
                }
            }
        }
        
    }
}
