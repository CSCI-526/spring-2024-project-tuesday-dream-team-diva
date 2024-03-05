using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class GraspingSystem : MonoBehaviour
{
    public Transform holdPos;
    public float throwForce = 10f;
    public bool isHolding = false;
    private RaycastEntity raycastEntity;
    private Transform currentObject;

    void Start()
    {
        raycastEntity = GetComponent<RaycastEntity>();
    }

    // Update is called once per frame
    void Update()
    {
        if (raycastEntity == null)
            return;

        if(Input.GetKeyDown(KeyCode.E))
        {
            currentObject = raycastEntity.GetCurrentObject();
            if (currentObject != null && !isHolding)
            {
                Rigidbody rb = currentObject.GetComponent<Rigidbody>();
                rb.useGravity = false;
                rb.velocity = Vector3.zero;
                rb.isKinematic = true;
                currentObject.position = holdPos.position;
                currentObject.parent = holdPos;
                isHolding = true;

                Debug.Log("Should be holding:" + currentObject);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isHolding)
            {
                Rigidbody rb= currentObject.GetComponent<Rigidbody>();
                rb.useGravity = true;
                rb.isKinematic = false;
                currentObject.parent = null;
                rb.AddForce(holdPos.forward * throwForce);
                isHolding = false;
            }

        }
    }
}
