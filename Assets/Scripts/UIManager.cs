using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void ReTry() {

        SceneManager.LoadScene("MainHun");
    }

    public void Roby() {
        SceneManager.LoadScene("Start");
    }
}
