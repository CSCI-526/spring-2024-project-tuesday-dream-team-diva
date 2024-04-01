using UnityEngine;

public class GraspingSystem : MonoBehaviour
{
    public Transform holdPos;
    public float throwForce = 10f;
    public GameObject currentHoldingObject = null;

    private void OnTriggerEnter(Collider other)
    {
        if(currentHoldingObject == null)
        {
            if(other.gameObject.CompareTag("freeze") || other.gameObject.CompareTag("reducespeed") || other.gameObject.CompareTag("hide tile"))
            {
                GrabObject(other.gameObject);
            }
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (currentHoldingObject != null)
            {
                ThrowObject();
            }
        }
    }

    private void GrabObject(GameObject obj)
    {
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
        obj.transform.position = holdPos.position;
        obj.transform.SetParent(holdPos);

        currentHoldingObject = obj;
    }

    private void ThrowObject()
    {

        if(currentHoldingObject == null)
        {
            return;
        }

        Rigidbody rb = currentHoldingObject.GetComponent<Rigidbody>();
        if (rb == null)
        {
            return;
        }

        rb.useGravity = true;
        rb.isKinematic = false;
        currentHoldingObject.transform.SetParent(null);
        rb.AddForce(-holdPos.forward * throwForce, ForceMode.Impulse);

        currentHoldingObject = null;
    }
}
