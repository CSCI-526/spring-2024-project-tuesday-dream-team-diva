using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Hoovertip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{ 
    
    //public float timetowait=0.1f;
    public GameObject InstructionsPlayer1;

    void Start(){
        InstructionsPlayer1.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData){
        
        InstructionsPlayer1.SetActive(true);
        

    }

    public void OnPointerExit(PointerEventData eventData){

        InstructionsPlayer1.SetActive(false);
        
        /*StopAllCoroutines();
        TooltipManager1.onMouseRemove();*/

    }

    /*private void showMessage(){
        //TooltipManager1.onMouseOver(Input.mousePosition);
    }

    private IEnumerator starttimer(){
       /* yield return new WaitForSeconds(timetowait);
        showMessage();
    }*/

    
}
