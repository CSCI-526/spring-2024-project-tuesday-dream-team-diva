using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onehint2 : MonoBehaviour
{
    public GameObject onetext1;
    

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("hint1"))
        {
            Debug.Log("1 hint!");
            
            
            

            if (onetext1 != null)
            {
                StartCoroutine(onetextvisible(1f));
            }
        }
        
    }

    IEnumerator onetextvisible(float duration)
    {
        
        onetext1.SetActive(true);

       
        yield return new WaitForSeconds(duration);


        onetext1.SetActive(false);
    }
}
