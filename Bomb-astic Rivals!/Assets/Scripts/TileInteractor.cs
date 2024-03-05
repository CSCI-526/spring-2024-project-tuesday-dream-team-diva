using System.Collections;
using UnityEngine;

public class TileInteractor : MonoBehaviour
{
    private bool hidden; // tracks whether or not the tile is showing it's value
    public SpriteRenderer spriteRenderer; // tracks image on tile
    public bool isBomb;

    void Start()
    {
        hidden = true;
        spriteRenderer.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(hidden)
        {
            spriteRenderer.enabled = true;
            hidden = false;

            Debug.Log("SHOW TILE");

            // if it's a bomb tile, destroy what lands on it
            if(isBomb)
            {
                if(other.CompareTag("Player") || other.gameObject.transform.parent.CompareTag("Player"))
                {
                    // move player back to starting position
                    other.gameObject.transform.position = new Vector3(0.0f, -3.5f, -198.5f);

                    //// do scoring here?
                    //if (other.gameObject.GetComponent<PlayerMovement1>()) // player one stepped on the bomb --> increase player two's score
                    //{

                    //}
                    //else // player two stepped on the bomb --> increase player one's score
                    //{

                    //}
                }
                else if(other.gameObject.transform.parent.CompareTag("Player"))
                {
                    Debug.Log("this is happening");
                }
                else
                {
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
    }
}
