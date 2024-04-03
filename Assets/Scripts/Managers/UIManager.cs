using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject pauseControlsMenu;
    public bool isPauseMenuActive = false;

    void Awake()
    {
        instance = this;
    }

    public void TurnOnPauseControls()
    {
        pauseControlsMenu.SetActive(true);
        Time.timeScale = 0.0f;
        isPauseMenuActive = true;
    }

    public void TurnOffPauseControls()
    {
        pauseControlsMenu.SetActive(false);
        Time.timeScale = 1.0f;
        isPauseMenuActive = false;
    }
}
