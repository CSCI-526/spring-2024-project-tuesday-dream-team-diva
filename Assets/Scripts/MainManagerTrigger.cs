using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManagerTrigger : MonoBehaviour
{
    public GameObject tutorial;
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;

    void Start()
    {
        if(MainManager.Instance != null)
        {
            MainManager.Instance.FindButtons();
            //MainManager.Instance.UpdateGameProgress();
            MainManager.Instance.SetSelectble();
        }
    }
}
