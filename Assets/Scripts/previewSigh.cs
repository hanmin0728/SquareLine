using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class previewSigh : MonoBehaviour
{
    //�ٸ���ü������ �Ҽ��ְ� �������̽���?
    SpriteRenderer sprite;

    public Color[] colors;
    private void Start() {
        sprite = GetComponent<SpriteRenderer>();
    }
    private void OnEnable() {
          
    }

    //IEnumerator colorToggle() {
    //    for (int i = 0; i < 4; i++) {

            
    //        sprite.color = 
    //        yield return new WaitForSeconds(0.3f);
    //    }
    //}
}
