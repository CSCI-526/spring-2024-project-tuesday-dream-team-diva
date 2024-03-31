using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tickhint1 : MonoBehaviour
{
    public GameObject ticktext1;
    

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("tick"))
        {
            Debug.Log("Tick hint!");
            
            
            

            if (ticktext1 != null)
            {
                StartCoroutine(ticktextvisible(1f));
            }
        }
        
    }

    IEnumerator ticktextvisible(float duration)
    {
        
        ticktext1.SetActive(true);

       
        yield return new WaitForSeconds(duration);


        ticktext1.SetActive(false);
    }
}
