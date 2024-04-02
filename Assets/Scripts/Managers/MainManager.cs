using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{

    public static MainManager Instance;
    [SerializeField] private int enabledLevelNumber=0;
    [SerializeField] private int currentLevelNumber;
    public GameObject tutorial;
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

        UpdateGameProgress();
        if (SceneManager.loadedSceneCount == 0)
        {
            SetSelectble();
        }
    }

    private void UpdateGameProgress()
    {
        int currentLevelNumber = SceneManager.loadedSceneCount;
        if (currentLevelNumber <= 1)
        {
            //enable tutorial
            enabledLevelNumber = 2;
        }
        else if (currentLevelNumber == 2)
        {
            //enable level 1 
            enabledLevelNumber = 3;
        }
        else if (currentLevelNumber == 3)
        {
            //enable level 2 
            enabledLevelNumber = 4;
        }
        else if (currentLevelNumber == 4)
        {
            //enable level 3 
            enabledLevelNumber = 5;
        }
        else if(currentLevelNumber == 5)
        {
            //enable level 4 
            enabledLevelNumber = 6;
        }
    }

    public void SetSelectble()
    {
        Debug.Log("Setting Selectable");
        if (enabledLevelNumber < 3) 
        { 
            level1.GetComponent<Button>().interactable = false;
        }
        if (enabledLevelNumber < 4)
        {
            level2.GetComponent<Button>().interactable = false;
        }
        if (enabledLevelNumber < 5)
        {
            level3.GetComponent<Button>().interactable = false;
        }
        if (enabledLevelNumber < 6)
        {
            level4.GetComponent<Button>().interactable = false;
        }
    }
}
