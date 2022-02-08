using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class previewSigh : MonoBehaviour
{
    //�ٸ���ü������ �Ҽ��ְ� �������̽���?
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
        //�ҷ� �ϴ¹���̶� �Լ��� �̰� �޾ư����� �̰��ϴ¹��
    }
}
