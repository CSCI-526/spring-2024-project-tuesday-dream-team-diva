using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer1 : MonoBehaviour
{
    private Vector3 offset = new Vector3(0, 3, 5);
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;

    }
}