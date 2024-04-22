using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class TileInteractor : MonoBehaviour
{
    public bool hidden; // tracks whether or not the tile is showing it's value
    public bool reveal;
    public SpriteRenderer spriteRenderer; // tracks image on tile
    public bool isBomb;
    // private bool enterBomb = false;
    [SerializeField] private GameObject analyticsManager;

    public Vector3 startingPosition = new Vector3(0.0f, -3.5f, -198.5f);

    void Start()
    {
        hidden = true;
        
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.enabled = false;
        }

        //reveal the bomb on loaded if reveal is checked
        if (!reveal)
        {
            spriteRenderer.enabled = false;
        }
        else
        {
            spriteRenderer.enabled = true;
        }


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
            }
            if(other.CompareTag("hide tile"))
            {
                spriteRenderer.enabled = false;
                hidden = true;
            }
        }
        
        
        
    }
    

    IEnumerator RespawnCoroutine(GameObject respawningCharacter)
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(2);

        if(respawningCharacter.GetComponent<PlayerMovement1>())
        {
            PlayerMovement1.instance.transform.position = PlayerMovement1.instance.respawnLocation;
        }
        else if(respawningCharacter.GetComponent<PlayerMovement2>())
        {
            PlayerMovement2.instance.transform.position = PlayerMovement2.instance.respawnLocation;
        }
        else
        {
            // respawn character and make them movable again
            respawningCharacter.transform.position = startingPosition;
        }

        respawningCharacter.SetActive(true);
    }
}
