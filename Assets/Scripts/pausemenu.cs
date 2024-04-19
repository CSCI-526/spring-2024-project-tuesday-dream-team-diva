using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausemenu : MonoBehaviour
{
    public GameObject pausedialog;
    
    public void openpausemenu(){
        pausedialog.SetActive(true);

    }


    public void resumegame(){
        pausedialog.SetActive(false);

    }
}
