using UnityEngine;

public class GraspingSystem : MonoBehaviour
{
    public Transform holdPos;
    public float throwForce = 10f;
    private bool isHolding = false;
    private Transform currentObject;

    private void OnTriggerEnter(Collider other)
    {
        if (!isHolding && ( other.gameObject.CompareTag("freeze") || other.gameObject.CompareTag("reducespeed") || other.gameObject.CompareTag("hide tile")))
        {
            currentObject = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == currentObject && !isHolding)
        {
            Debug.Log("OnTriggerExit: Setting currentObject to null");
            currentObject = null;
        }
    }

    public void SetCurrentObject(Transform newObject)
    {
        if (newObject == null)
        {
            Debug.Log("SetCurrentObject: Setting currentObject to null");
        }
        else
        {
            Debug.Log($"SetCurrentObject: Setting currentObject to {newObject.name}");
        }
        currentObject = newObject;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && !isHolding && currentObject != null)
        {
            GrabObject();
            
        }
        else if (Input.GetKeyDown(KeyCode.R) && isHolding)
        {
            ThrowObject();
        }

        if (isHolding && currentObject != null)
        {
            currentObject.position = holdPos.position;
        }
    }

    private void GrabObject()
    {
        Debug.Log($"Before grabbing, isHolding: {isHolding}");
        Rigidbody rb = currentObject.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
        currentObject.position = holdPos.position;
        currentObject.SetParent(holdPos);
        isHolding = true;
        Debug.Log($"after grabbing, isHolding: {isHolding}");
    }


    private void ThrowObject()
    {
        Debug.Log($"before throw, isHolding: {isHolding}");

        if (currentObject == null)
        {
            Debug.LogError("Attempt to throw a null object.");
            isHolding = false;
            return;
        }

        Rigidbody rb = currentObject.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found on the object to throw.");
            isHolding = false;
            return;
        }


        if (holdPos == null)
        {
            Debug.LogError("holdPos has not been assigned.");
            isHolding = false;
            return; 
        }

        rb.useGravity = true;
        rb.isKinematic = false;
        currentObject.SetParent(null);
        rb.AddForce(holdPos.forward * throwForce, ForceMode.Impulse);
        isHolding = false;
        currentObject = null; 
    }



}
