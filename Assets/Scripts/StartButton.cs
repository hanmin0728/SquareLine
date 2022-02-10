using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{


    public RectTransform[] TutorialObject;
    public int index;
    private void Awake() {
 
    }
    public void Quit() {
        Application.Quit();
    }
    public void StartButtonsd() {
        SceneManager.LoadScene("MainHun");
    }



    public void TutorialAppear() {

        if(index != 0) {
            return;
        }
    

        index = 0;
        TutorialObject[0].anchoredPosition = Vector2.zero;
   
    }


    public void TutoNext() {
        TutorialObject[index].anchoredPosition = Vector2.up * 10000;
        index++;

        if(index == 1) {
            TutorialObject[index].anchoredPosition = new Vector2(0, -106);
        }
        else
        TutorialObject[index].anchoredPosition = Vector2.zero;
    }

    public void TutoExit(int index) {
    
        TutorialObject[index].anchoredPosition = Vector2.up * 10000;
        this.index = 0;
    }

   
}
