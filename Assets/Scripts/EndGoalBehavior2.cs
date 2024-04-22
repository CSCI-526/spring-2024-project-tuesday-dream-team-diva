// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class EndGoalBehaviour2 : MonoBehaviour
// {
//     public GameObject endGameCanvas1;
    

//     void OnTriggerEnter(Collider other)
//     {
//         if(other.CompareTag("endline2"))
//         {
//             Debug.Log("Player reached the end goal!");
            
//             // stop time
            

//             if(endGameCanvas1)
//             {
//                 // display end game canvas
//                 endGameCanvas1.SetActive(true);
//                 Time.timeScale = 0.0f;

//                 if(MainManager.Instance != null)
//                 {
//                     MainManager.Instance.UpdateGameProgress();
//                 }
//             }
//         }
        
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoalBehavior2 : MonoBehaviour
{
    public GameObject endGameCanvas1;
    public EndGoalBehavior1 check;

    public bool reached = false;
     public GameObject nextLevels;


  void Start()
    {
        reached = false;
    }

    void Update ()
    {
        if (check != null)
        {

            if (check.reached && reached)
            {
                nextLevels.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
    }
    

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("endline2"))
        {
            Debug.Log("Player reached the end goal!");
            
            // stop time
            reached = true;

            PlayerMovement2.instance.canMove = false;

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
