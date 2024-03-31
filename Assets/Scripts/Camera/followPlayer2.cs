using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer2 : MonoBehaviour
{
   private Vector3 offset = new Vector3(0, 3, 5);
    public GameObject player;

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}