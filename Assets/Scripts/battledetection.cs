using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class battledetection : MonoBehaviour
{
    public GameObject board;
    private Collider firstPlayer;
    private Collider secondPlayer;
    private bool firstPlayerEnters;
    private bool secondPlayerEnters;
    private bool battlestarted;

    private float battleTime;

    // Start is called before the first frame update
    void Start()
    {
        firstPlayerEnters = false;
        secondPlayerEnters = false;
        battlestarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (battlestarted)
        {
            board.transform.Translate(Vector3.up * Time.deltaTime, Space.World);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !battlestarted && !firstPlayerEnters)
        {
            Debug.Log("1st player Enters");
            firstPlayerEnters = true;
            firstPlayer = other;
        }

        if (other.CompareTag("Player") && !battlestarted && other!=firstPlayer)
        {
            Debug.Log("2nd player Enters");
            secondPlayerEnters = true;
        }

        if (firstPlayerEnters&& secondPlayerEnters)
        {
            battlestarted = true;
        }
    }
}
