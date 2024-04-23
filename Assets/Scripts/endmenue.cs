using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class endmenue : MonoBehaviour
{
    public void loadmainmenue()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadSceneAsync(0);
    }

    public void aboutscreen()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadSceneAsync(1);
    }

    public void loadtutorial1()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadSceneAsync(2);
    }

    public void loadtutorial2()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadSceneAsync(3);
    }
    public void loadtutorial3()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadSceneAsync(4);
    }

    public void loadlevel1()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadSceneAsync(5);
    }

    public void loadlevel2()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadSceneAsync(6);
    }

    public void loadlevel3()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadSceneAsync(7);
    }

    public void loadlevel4()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadSceneAsync(8);
    }
    public void loadlevel5()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadSceneAsync(9);
    }

    public void loadtutorialscreen()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadSceneAsync(10);
    }
}
