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

   public void loadtutorial1(){
        SceneManager.LoadScene(2);
        Time.timeScale = 1.0f;
    }

    public void loadtutorial2(){
        SceneManager.LoadScene(3);
        Time.timeScale = 1.0f;
    }
    public void loadtutorial3(){
        SceneManager.LoadScene(4);
        Time.timeScale = 1.0f;
    }

    public void loadlevel1(){
        SceneManager.LoadSceneAsync(5);
        Time.timeScale = 1.0f;
    }

    public void loadlevel2(){
        SceneManager.LoadSceneAsync(6);
        Time.timeScale = 1.0f;
    }

    public void loadlevel3(){
        SceneManager.LoadSceneAsync(7);
        Time.timeScale = 1.0f;
    }

    public void loadlevel4(){
        SceneManager.LoadSceneAsync(8);
        Time.timeScale = 1.0f;
    }

    public void loadtutorialscreen(){
        SceneManager.LoadSceneAsync(9);
        Time.timeScale = 1.0f;
    }

}
