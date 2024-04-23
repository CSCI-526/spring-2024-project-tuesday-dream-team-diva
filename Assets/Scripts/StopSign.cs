using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSign : MonoBehaviour
{

    public GameObject bomb1;
    public GameObject bomb2;
    public GameObject bomb3;
    public GameObject bomb4;
    public GameObject bomb5;
    [SerializeField] bool bomb1_Hidden;
    [SerializeField] bool bomb2_Hidden;
    [SerializeField] bool bomb3_Hidden;
    [SerializeField] bool bomb4_Hidden;
    [SerializeField] bool bomb5_Hidden;

    // Start is called before the first frame update
    void Start()
    {
        bomb1_Hidden = false;
        bomb2_Hidden = false;
        bomb3_Hidden = false;
        bomb4_Hidden = false;
        bomb5_Hidden = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (bomb1 != null)
        {
            bomb1_Hidden = bomb1.GetComponent<TileInteractor>().hidden;
        }
        if (bomb2 != null)
        {
            bomb2_Hidden = bomb2.GetComponent<TileInteractor>().hidden;
        }
        if (bomb3 != null)
        {
            bomb3_Hidden = bomb3.GetComponent<TileInteractor>().hidden;
        }
        if (bomb4 != null)
        {
            bomb4_Hidden = bomb4.GetComponent<TileInteractor>().hidden;
        }
        if (bomb5 != null)
        {
            bomb5_Hidden = bomb5.GetComponent<TileInteractor>().hidden;
        }

            if (bomb1_Hidden && bomb2_Hidden && bomb3_Hidden && bomb4_Hidden && bomb5_Hidden)
            {
                this.gameObject.SetActive(false);
            }
        
    }
}
