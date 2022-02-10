using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public GameObject TextMeshprotest;
    TextMeshProUGUI text;

    public int addScore;
    private void Awake() {
        text = TextMeshprotest.GetComponent<TextMeshProUGUI>();
        instance = this;

        PlayerPrefs.GetInt("score", addScore);
        StartCoroutine(ScoreAdd());
        
    }

    IEnumerator ScoreAdd() {
        while(true) {
            if(GameManager.TimeScale <=0) {
                yield break ; 
            }

            AddScore(10);
            yield return new WaitForSeconds(3f);
        }


    }

    
    private void Update() {
        
    }

    public void UpdateScore(int score) {
        text.text =  score.ToString() + "socre";
        PlayerPrefs.SetInt("score", addScore);
    }
    public void AddScore(int amount) {
        addScore += amount;
        UpdateScore(addScore);

    }

}
