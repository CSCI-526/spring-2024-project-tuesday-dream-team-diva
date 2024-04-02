using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class TileInteractor : MonoBehaviour
{
    private bool hidden; // tracks whether or not the tile is showing it's value
    public SpriteRenderer spriteRenderer; // tracks image on tile
    public bool isBomb;

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

                    StartCoroutine(RespawnCoroutine(other.gameObject));
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

    IEnumerator RespawnCoroutine(GameObject respawningCharacter)
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(2);

        // respawn character and make them movable again
        respawningCharacter.transform.position = startingPosition;
        respawningCharacter.SetActive(true);
    }
}
