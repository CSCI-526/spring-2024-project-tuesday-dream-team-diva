using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class TileInteractor : MonoBehaviour
{
    private bool hidden; // tracks whether or not the tile is showing it's value
    public SpriteRenderer spriteRenderer; // tracks image on tile
    public bool isBomb;
    // private bool enterBomb = false;
    [SerializeField] private GameObject analyticsManager;

    public Vector3 startingPosition = new Vector3(0.0f, -3.5f, -198.5f);

    void Start()
    {
        hidden = true;
        //add
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        spriteRenderer.enabled = false;

        analyticsManager = GameObject.Find("Analytics Manager");

        
    }

    void Update() 
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(hidden)
        {
            spriteRenderer.enabled = true;
            hidden = false;

            //Debug.Log("SHOW TILE");

            // if it's a bomb tile, destroy what lands on it
            if(isBomb)
            {
                //add other.gameObject.transform.parent != null &&
                if (other.CompareTag("Player") || (other.gameObject.transform.parent != null && other.gameObject.transform.parent.CompareTag("Player")))
                {
                    
                    other.gameObject.SetActive(false);

                    //send BombTriggeredByPlayer event
                    analyticsManager.GetComponent<AnalyticsManager>().BombTriggeredByPlayer();

                    //send LocationOfDeath event
                    //define bombTileIdentifier
                    GameObject tile = gameObject.transform.parent.gameObject;
                    string tileName = tile.name;
                    GameObject set = tile.transform.parent.gameObject;
                    string setName = set.name;
                    string bombTileIdentifier = setName + ": " + tileName;
                    //define x and y coordinate
                    float xAxis = tile.transform.position.x;
                    float yAxis = tile.transform.position.y;
                    //LocationOfDeath(bool isBombTile, string bombTileIdentifier, float xAxis, float yAxis)
                    analyticsManager.GetComponent<AnalyticsManager>().LocationOfDeath(true, bombTileIdentifier, xAxis, yAxis);
                    
                    StartCoroutine(RespawnCoroutine(other.gameObject));
                }
                else
                {
                    //send BombTriggeredByItem event
                    analyticsManager.GetComponent<AnalyticsManager>().BombTriggeredByItem();
                    Destroy(other.gameObject);  
                }
            }
        }
        else
        {
            if(other.CompareTag("hide tile"))
            {
                spriteRenderer.enabled = false;
                hidden = true;
            }
        }
        //by Julianna
        if(hidden==false)
        {
            if(isBomb)
            {
                //add other.gameObject.transform.parent != null &&
                if (other.CompareTag("Player") || (other.gameObject.transform.parent != null && other.gameObject.transform.parent.CompareTag("Player")))
                {
                    
                    other.gameObject.SetActive(false);

                    //send BombTriggeredByPlayer event
                    analyticsManager.GetComponent<AnalyticsManager>().BombTriggeredByPlayer();

                    //send LocationOfDeath event
                    //define bombTileIdentifier
                    GameObject tile = gameObject.transform.parent.gameObject;
                    string tileName = tile.name;
                    GameObject set = tile.transform.parent.gameObject;
                    string setName = set.name;
                    string bombTileIdentifier = setName + ": " + tileName;
                    //define x and y coordinate
                    float xAxis = tile.transform.position.x;
                    float yAxis = tile.transform.position.y;
                    //LocationOfDeath(bool isBombTile, string bombTileIdentifier, float xAxis, float yAxis)
                    analyticsManager.GetComponent<AnalyticsManager>().LocationOfDeath(true, bombTileIdentifier, xAxis, yAxis);
                    
                    StartCoroutine(RespawnCoroutine(other.gameObject));
                }
                else
                {
                    //send BombTriggeredByItem event
                    analyticsManager.GetComponent<AnalyticsManager>().BombTriggeredByItem();
                    Destroy(other.gameObject);  
                }
            }

        }
        
        
    }
    

    IEnumerator RespawnCoroutine(GameObject respawningCharacter)
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(2);

        // respawn character and make them movable again
        respawningCharacter.transform.position = startingPosition;
        respawningCharacter.SetActive(true);
    }
}
