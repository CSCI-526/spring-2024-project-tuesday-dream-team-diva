using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class falldetection : MonoBehaviour
{
    private Vector3 respawn;
    public GameObject Falldetector;
    [SerializeField] private GameObject analyticsManager;

    void Start()
    {
        respawn = transform.position;

        analyticsManager = GameObject.Find("Analytics Manager");
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("fallDetector"))
        {
            //send LocationOfDeath event
            //define bombTileIdentifier
            string bombTileIdentifier = "Non-Applicable";
            //define x and y coordinate
            float xAxis = gameObject.transform.position.x;
            float yAxis = gameObject.transform.position.y;
            //LocationOfDeath(bool isBombTile, string bombTileIdentifier, float xAxis, float yAxis)
            analyticsManager.GetComponent<AnalyticsManager>().LocationOfDeath(false, bombTileIdentifier, xAxis, yAxis);
            
            if(gameObject.GetComponent<PlayerMovement1>())
            {
                PlayerMovement1.instance.transform.position = PlayerMovement1.instance.respawnLocation;
            }
            else if(gameObject.GetComponent<PlayerMovement2>())
            {
                PlayerMovement2.instance.transform.position = PlayerMovement2.instance.respawnLocation;
            }
            else
            {
                transform.position = respawn;
            }
        }
    }

    
}
