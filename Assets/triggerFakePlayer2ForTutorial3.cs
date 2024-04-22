using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerFakePlayer2ForTutorial3 : MonoBehaviour
{
    public GameObject fake;
    public Vector3 resetPosition = Vector3.zero; // Position to reset the fake GameObject
    public float resetDelay = 1f; // Delay before resetting the fake position
    private bool wasSpriteRendererEnabled = true;
    private bool activated = false;
    public Vector3[] waypoints;
    public float speed =0.000000000000000000000000000000000000000000000001f;

    private int currentWaypointIndex = 0;
    private bool shouldMove = true;

    public PlayerMovement1 player;

    public GraspingSystem holding;

    void Start()
    {
        waypoints = new Vector3[]
        {
            new Vector3(-3.75f, -3.25f, -204.569f),
            new Vector3(-3.48f, -3.25f, -211.5f),
            new Vector3(0f, -3.25f, -211f)
        };

        fake.SetActive(false);
        wasSpriteRendererEnabled = GetComponent<SpriteRenderer>().enabled;

        if (waypoints.Length == 0)
        {
            Debug.LogError("No waypoints defined!");
        }
    }

    void Update()
    {
        // // fake.SetActive(false);
        // bool isSpriteRendererEnabled = GetComponent<SpriteRenderer>().enabled;

        // if (wasSpriteRendererEnabled && !isSpriteRendererEnabled && !activated)
        // {
        //     // If SpriteRenderer was enabled and is now disabled for the first time
        //     activated = true;

            // Start coroutine to reset fake position after a delay

                   if (holding.currentHoldingObject.CompareTag("freeze"))
        {
                        if(player.gameObject.transform.position.z <-207 && holding.currentHoldingObject.CompareTag("freeze")){
            player.canMove=false;
            StartCoroutine(ResetFakePositionAfterDelay());
        }
        else {
            player.canMove=true;
        }

            
        }
            // StartCoroutine(ResetFakePositionAfterDelay());
        // }
        // //  else {
        // //     fake.SetActive(false);
        // // }

        // // Update the state of the SpriteRenderer for the next frame
        // wasSpriteRendererEnabled = isSpriteRendererEnabled;
    }

    IEnumerator ResetFakePositionAfterDelay()
    {
        fake.SetActive(true);
         if(player.gameObject.transform.position.z <-207){
            player.canMove=false;
        }
        yield return new WaitForSeconds(resetDelay);

        // After the delay, start moving the fake GameObject along the preset path
        StartCoroutine(PresetMove());
    }

    IEnumerator PresetMove()
    {
        while (shouldMove && currentWaypointIndex < waypoints.Length)
        {
            Vector3 targetPosition = waypoints[currentWaypointIndex];
            fake.transform.position = Vector3.MoveTowards(fake.transform.position, targetPosition, speed * Time.deltaTime);

            if (Vector3.Distance(fake.transform.position, targetPosition) < 0.01f)
            {
                // Move to the next waypoint
                currentWaypointIndex++;

                // If there are no more waypoints, stop the movement
                if (currentWaypointIndex >= waypoints.Length)
                {
                    shouldMove = false;

                    // Start coroutine to wait before destroying the fake GameObject
                    StartCoroutine(WaitAndDestroy());
                }
            }

            yield return null;
        }
    }

    IEnumerator WaitAndDestroy()
    {
        Debug.Log("Waiting to destroy");
         // Adjust the delay as needed

        // Deactivate and destroy the fake GameObject
        // Set the position of the fake GameObject to its current position
        Vector3 currentPosition = fake.transform.position;
        fake.transform.position = currentPosition;

        // Wait for a specified duration
        yield return new WaitForSeconds(2f); // Adjust the delay as needed

        // Set the fake GameObject's position to its current position and deactivate it
     player.canMove =true;
        // fake.SetActive(false);
        // player.canMove =true;
        Debug.Log("Fake GameObject deactivated");
    }
}
