using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingManager : MonoBehaviour
{
    public static FloatingManager instance;

    public Transform hudPos; 
    public GameObject hudTextMeshCanvas; //여기에 텍스트메쉬프로
    
    private void Awake() {
        instance = this;
    }
    public void TextMeshFloating(string _text ,Color? c  = null, Transform pos = null) {
        GameObject hudText;
        Camera camera = Camera.main;
        Transform currentPos = hudPos;
        
        if (pos != null) 
            currentPos = pos;


        hudText = Instantiate(hudTextMeshCanvas, hudPos);
        hudText.transform.parent = null;

        hudText.GetComponentInChildren<TextMeshProUGUI>().text = _text;
        //print(c.Value);
        //print("color는?" + (c.HasValue ? c.Value : Color.white));
        hudText.GetComponentInChildren<TextMeshProUGUI>().color = c.HasValue ? c.Value : Color.white;
        //print("텍스트이 컬러는?" + hudText.GetComponentInChildren<TextMeshProUGUI>().color);


        TestMeshProText test = hudText.GetComponentInChildren<TestMeshProText>();
        test.SetColor(hudText.GetComponentInChildren<TextMeshProUGUI>().color);
        //이게원인이 이유가 부모가 있는 상태에서 포지션을 지정해주었기 때문에 그렇구만

        hudText.transform.position =   currentPos.position; //게임매니저가 휴드포스



    }

    
}
