using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer2 : MonoBehaviour
{
    public Vector3 positionOffset = new Vector3(0, 5, -5);
    public Vector3 rotationOffset = new Vector3(30, 0, 0);
    public GameObject player;
    private float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        Vector3 desiredPosition = player.transform.position + player.transform.rotation * positionOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        Quaternion desiredRotation = player.transform.rotation * Quaternion.Euler(rotationOffset);
        Quaternion smoothedRotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothSpeed);
        transform.rotation = smoothedRotation;
    }
}