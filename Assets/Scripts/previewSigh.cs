using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class previewSigh : MonoBehaviour
{
    //다른객체에서도 할수있게 인터페이스로?
    SpriteRenderer sprite;

    public Color[] colorSet = new Color[2];
    int idx = 0;
    public bool isColorComplet = false;
    private void Start() {
        sprite = GetComponent<SpriteRenderer>();
        StopCoroutine(colorToggle());
        StartCoroutine(colorToggle());
    }


    IEnumerator colorToggle() {
       
        for (int i = 0; i < 4; i++) {

            sprite.color = colorSet[0];
            yield return new WaitForSeconds(0.15f);
            sprite.color = colorSet[1];
            yield return new WaitForSeconds(0.15f);

        }


        gameObject.SetActive(false);
        isColorComplet = true;
        //불로 하는방법이랑 함수로 이걸 받아가지고 이걸하는방법
    }
}
