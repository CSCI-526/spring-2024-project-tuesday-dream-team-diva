using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject startGameAnnoncement;
    public float annoncementTime = 2f;

    public enum StateType
    {
        GAMESTART,
        GAMEOVER
    };

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ToggleAnnoncement());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ToggleAnnoncement()
    {
        yield return new WaitForSeconds(annoncementTime);
        startGameAnnoncement.SetActive(false);
    }
}
