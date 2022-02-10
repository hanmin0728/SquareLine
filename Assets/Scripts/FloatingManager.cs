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

        Transform currentPos = hudPos;
        print(pos);
        if (pos != null) 
            currentPos = pos;


        hudText = Instantiate(hudTextMeshCanvas, hudPos);



        hudText.transform.position = currentPos.position;
        hudText.transform.parent = null;

        hudText.GetComponentInChildren<TextMeshProUGUI>().text = _text;
        //print(c.Value);
        //print(c.HasValue);
        hudText.GetComponentInChildren<TextMeshProUGUI>().color = c.HasValue ? c.Value : Color.white;




    }
}
