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

        if(Input.GetKeyDown(KeyCode.Z))
        {
            currentObject = raycastEntity.GetCurrentObject();
            if (currentObject != null && raycastEntity.GetCurrentObject().tag == "Item" && isHolding == false)
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

        if (Input.GetKeyDown(KeyCode.X))
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
