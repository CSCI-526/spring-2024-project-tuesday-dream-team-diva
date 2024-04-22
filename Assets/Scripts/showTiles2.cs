using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showTiles2 : MonoBehaviour
{
    public GameObject setTiles;
    public GraspingSystem2 holding;
    
    public SpriteRenderer[] spriteRenderers;
    public TileInteractor[] scripts;
    public static bool hiding;


    void Start(){
        setTiles.SetActive(false);
        // spriteRenderers = setTiles.GetComponentsInChildren<SpriteRenderer>();
        // scripts = FindObjectsOfType<TileInteractor>();
            // foreach (SpriteRenderer spriteRenderer in spriteRenderers)
            // {
            //     spriteRenderer.enabled = true;
            // }
        // foreach (TileInteractor script in scripts)
        //     {
        //         script.hidden = false;
        //     }
  
    }

    void Update() 
    {
        
  
        // if (holding.currentHoldingObject.CompareTag("hide tile"))
        // {
        //     setTiles.SetActive(true);
        //     // foreach (SpriteRenderer spriteRenderer in spriteRenderers)
        //     // {
        //     //     spriteRenderer.enabled = true;
        //     // }
            
        
        // }


    }

    void OnTriggerEnter(Collider other)
    {
        // spriteRenderers = setTiles.GetComponentsInChildren<SpriteRenderer>();
        // scripts = FindObjectsOfType<TileInteractor>();
     
        if (other.CompareTag("hide tile"))
        {
            setTiles.SetActive(true);
            // spriteRenderers = setTiles.GetComponentsInChildren<SpriteRenderer>();
            // foreach (SpriteRenderer spriteRenderer in spriteRenderers)
            // {
            //     spriteRenderer.SetActive(true);
            // }
            scripts = setTiles.GetComponentsInChildren<TileInteractor>();

            foreach (TileInteractor script in scripts)
            {
                script.spriteRenderer.enabled = true;
                script.hidden = false;
            }
        }

        if (other.CompareTag("freeze")){
            setTiles.SetActive(true);
            scripts = setTiles.GetComponentsInChildren<TileInteractor>();
               foreach (TileInteractor script in scripts)
            {
                script.spriteRenderer.enabled = false;
                script.hidden = true;
            }
        }
           
            //  foreach (TileInteractor script in scripts)
            // {
            //     script.hidden = false;
            // }
            // foreach (SpriteRenderer spriteRenderer in spriteRenderers)
            // {
            //     spriteRenderer.enabled = true;
            // }
        
        
        // if(other.CompareTag("hide tile"))
        //     {
        //         spriteRenderer.gameObject.enabled = false;
        //         hidden = true;
        //     }
       
        
  

    }
    

    
}