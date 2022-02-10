using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{


    public RectTransform num;
    public RectTransform num1;

    public void Quit() {
        Application.Quit();
    }
    public void StartButtonsd() {
        SceneManager.LoadScene("MainHun");
    }

    public void TutoExit() {
        num.anchoredPosition = Vector2.up * 10000;
    }

    public void TutoExit2() {
  
        num1.anchoredPosition = Vector2.up * 10000;


    }
    public void TutoRial() {
        num.anchoredPosition = Vector2.zero;
    }

    public void TutoRial2() {
        num.anchoredPosition = Vector2.up * 10000;
        num1.anchoredPosition = new Vector2(0, -106);
    }
   
}
