using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class endmenue : MonoBehaviour
{
   public void loadmainmenue(){
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1.0f;
    }

    public void aboutscreen(){
        SceneManager.LoadSceneAsync(1);
        Time.timeScale = 1.0f;
    }

   public void loadtutorial(){
        SceneManager.LoadSceneAsync(2);
        Time.timeScale = 1.0f;
    }

    public void loadlevel1(){
        SceneManager.LoadSceneAsync(3);
        Time.timeScale = 1.0f;
    }

    public void loadlevel2(){
        SceneManager.LoadSceneAsync(4);
        Time.timeScale = 1.0f;
    }

    public void loadlevel3(){
        SceneManager.LoadSceneAsync(5);
        Time.timeScale = 1.0f;
    }

    public void loadlevel4(){
        SceneManager.LoadSceneAsync(6);
        Time.timeScale = 1.0f;
    }
}
