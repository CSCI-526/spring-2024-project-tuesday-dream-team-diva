using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSign : MonoBehaviour
{

    public GameObject bomb;
    public bool bomb_Hidden;

    // Start is called before the first frame update
    void Start()
    {
        bomb_Hidden = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (bomb != null)
        {
            bomb_Hidden = bomb.GetComponent<TileInteractor>().hidden;
        }

        if (bomb_Hidden)
        {
            this.gameObject.SetActive(false);
        }

    }
}