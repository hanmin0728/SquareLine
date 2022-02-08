using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class previewSigh : MonoBehaviour
{
    //다른객체에서도 할수있게 인터페이스로?
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
