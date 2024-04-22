using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{

    public static MainManager Instance;

    [SerializeField] private int enabledLevelNumber = 0;
    [SerializeField] private int currentLevelNumber;
    public GameObject tutorial;
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;
    public GameObject level5;

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

        FindButtons();
        UpdateGameProgress();
        if (SceneManager.loadedSceneCount == 0)
        {
            SetSelectble();
        }
    }

    public void FindButtons()
    {
        if (SceneManager.GetActiveScene().name == "StartScreen")
        {
            if (tutorial == null)
            {
                tutorial = GameObject.Find("Canvas/Tutorial");
            }

            if (level1 == null)
            {
                level1 = GameObject.Find("Canvas/Level1");
            }

            if (level2 == null)
            {
                level2 = GameObject.Find("Canvas/Level2");
            }

            if (level3 == null)
            {
                level3 = GameObject.Find("Canvas/Level3");
            }

            if (level4 == null)
            {
                level4 = GameObject.Find("Canvas/Level4");
            }

            if(level5 == null)
            {
                level5 = GameObject.Find("Canvas/Level5");
            }
        }
    }

    public void UpdateGameProgress()
    {
        int currentLevelNumber = SceneManager.GetActiveScene().buildIndex; // get the index of this scene in the build
        if (currentLevelNumber <= 3 || currentLevelNumber == 10)
        {
            //enable tutorial
            enabledLevelNumber = 2;
        }
        else if (currentLevelNumber == 4) // Tutorial-3
        {
            //enable level 1 
            enabledLevelNumber = 3;
        }
        else if (currentLevelNumber == 5) // Level 1
        {
            //enable level 2 
            enabledLevelNumber = 4;
        }
        else if (currentLevelNumber == 6) // level 2
        {
            //enable level 3 
            enabledLevelNumber = 5;
        }
        else if(currentLevelNumber == 7) // level 3
        {
            //enable level 4 
            enabledLevelNumber = 6;
        }
        else if(currentLevelNumber == 8) // level 4
        {
            // enable level 5
            enabledLevelNumber = 7;
        }
    }

    public void SetSelectble()
    {
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
        if(enabledLevelNumber < 7)
        {
            level5.GetComponent<Button>().interactable = false;
        }
    }
}
