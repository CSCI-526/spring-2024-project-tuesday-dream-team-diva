using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class endmenue : MonoBehaviour
{
   public void loadmainmenue(){
        SceneManager.LoadSceneAsync(0);
    }

   public void loadtutorial(){
        SceneManager.LoadSceneAsync(1);
    }

    public void loadlevel1(){
        SceneManager.LoadSceneAsync(2);
    }

    public void loadlevel2(){
        SceneManager.LoadSceneAsync(3);
    }
}
