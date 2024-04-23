using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropFreezeItem : MonoBehaviour
{
    public GameObject freezeItem;
    private Rigidbody rb;
    private bool alreadyTriggered;

    // Start is called before the first frame update
    void Start()
    {
        alreadyTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (freezeItem!= null)
        {
            rb = freezeItem.GetComponent<Rigidbody>();
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !alreadyTriggered)
        {
            rb.useGravity = true;
            rb.isKinematic = false;
            alreadyTriggered = true;
        }
    }
}
