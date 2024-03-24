using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falldetection : MonoBehaviour
{
    private Vector3 respawn;
    public GameObject Falldetector; 
    void Start()
    {
        respawn = transform.position;
        
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("fallDetector"))
        {
            transform.position = respawn;
        }
    }

    
}
