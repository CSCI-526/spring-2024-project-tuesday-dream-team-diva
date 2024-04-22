using UnityEngine;
using System.Diagnostics;

public class GraspingSystem : MonoBehaviour
{
    public Transform holdPos;
    public float throwForce = 10f;
    public GameObject currentHoldingObject = null;
    public GameObject analyticsManager;
    public GameObject freezeactivate;
    public GameObject hideactivate;

    public GameObject throwReticle;

    private void OnTriggerEnter(Collider other)
    {
        if (currentHoldingObject == null)
        {
            if (other.gameObject.CompareTag("freeze") || other.gameObject.CompareTag("reducespeed") || other.gameObject.CompareTag("hide tile"))
            {
                GrabObject(other.gameObject);
            }

            if (other.gameObject.CompareTag("freeze"))
            {
                freezeactivate.SetActive(true);
            }

            if (other.gameObject.CompareTag("hide tile"))
            {
                hideactivate.SetActive(true);
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

        if(throwReticle)
        {
            throwReticle.SetActive(true);
        }
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

        if (currentHoldingObject.CompareTag("freeze"))
        {
            analyticsManager.GetComponent<AnalyticsManager>().BlueItemUsed();
        }

        if (currentHoldingObject.CompareTag("reducespeed"))
        {
            analyticsManager.GetComponent<AnalyticsManager>().RedItemUsed();
        }

        if (currentHoldingObject.CompareTag("hide tile"))
        {
            analyticsManager.GetComponent<AnalyticsManager>().BlackItemUsed();
        }

        rb.useGravity = true;
        rb.isKinematic = false;
        currentHoldingObject.transform.SetParent(null);
        rb.AddForce(-holdPos.forward * throwForce, ForceMode.Impulse);

        currentHoldingObject = null;
        freezeactivate.SetActive(false);
        hideactivate.SetActive(false);

        if (throwReticle)
        {
            throwReticle.SetActive(false);
        }
    }
}
