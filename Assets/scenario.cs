using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenario : MonoBehaviour
{
    // public GameObject fakeplayer;
    public Vector3[] waypoints;
    public float speed = 3f; 

    private int currentWaypointIndex = 0; 
    private bool shouldMove = true;

    // Start is called before the first frame update
    void Start()
    {
        // fakeplayer.SetActive(false);
        waypoints = new Vector3[]
    {
        new Vector3(-3.75f, -3.25f, -204.569f),
        new Vector3(-3.48f, -3.25f, -212.3647f),
        new Vector3(0f, -3.25f, -210.7919f),
        new Vector3(-5f,-3.25f,-200f)
    };

    }

    // Update is called once per frame
    void Update()
    {
        presetMove();
    }
    void presetMove()
    {
        if (shouldMove && waypoints.Length > 0)
        {
            Vector3 targetPosition = waypoints[currentWaypointIndex];
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    // Stop the movement
                    shouldMove = false;
                }
            }
        }


    }
}
