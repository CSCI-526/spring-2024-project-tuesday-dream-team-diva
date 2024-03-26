using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastEntity2 : MonoBehaviour
{
    public float raycastDistance = 10f;
    public Vector3 offset = new Vector3(0f, -1f, 0f);

    public Transform currentObject;

    // Removed Update method
    public void PerformRaycast2()
    {
        Vector3 forward = transform.forward;
        Vector3 portPos = transform.position + offset; ;
        RaycastHit hit;
        if (Physics.Raycast(portPos, forward, out hit, raycastDistance))
        {
            Debug.DrawRay(portPos, forward * hit.distance, Color.green);
            //fixed
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Hit a player, ignoring...");
                currentObject = null;
            }
            else
            {
                Debug.Log("debug: " + hit.collider.gameObject.name);
                currentObject = hit.transform;
            }
            
        }
        else
        {
            Debug.DrawRay(portPos, forward * raycastDistance, Color.green);
            currentObject = null;
        }
    }

    public Transform GetCurrentObject()
    {
        return currentObject; ;
    }


}