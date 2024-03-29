using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class GraspingSystem2 : MonoBehaviour
{
    public Transform holdPos;
    public float throwForce = 10f;
    public bool isHolding = false;
    private RaycastEntity2 raycastEntity2;
    private Transform currentObject;

    void Start()
    {
        raycastEntity2 = GetComponent<RaycastEntity2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (raycastEntity2 == null)
            return;

        if (Input.GetKeyDown(KeyCode.U))
        {
            if (isHolding)
            {
                return;
            }
            raycastEntity2.PerformRaycast2(); // new
            currentObject = raycastEntity2.GetCurrentObject();
            if (currentObject != null && !isHolding)
            {
                Rigidbody rb = currentObject.GetComponent<Rigidbody>();
                rb.useGravity = false;
                rb.velocity = Vector3.zero;
                rb.isKinematic = true;
                currentObject.position = holdPos.position;
                currentObject.parent = holdPos;
                isHolding = true;
            }


        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (isHolding)
            {
                Rigidbody rb = currentObject.GetComponent<Rigidbody>();
                rb.useGravity = true;
                rb.isKinematic = false;
                currentObject.parent = null;
                rb.AddForce(holdPos.forward * throwForce);
                isHolding = false;
            }

        }
        //fixed
        if (isHolding)
        {
            currentObject.position = holdPos.position;
        }
    }
}
