using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingManager : MonoBehaviour
{
    public static FloatingManager instance;

    public Transform hudPos; 
    public GameObject hudTextMeshCanvas; //���⿡ �ؽ�Ʈ�޽�����
    
    private void Start() {
        instance = this;
    }
    public void TextMeshFloating(string _text , Color? c  = null) {

        GameObject hudText = Instantiate(hudTextMeshCanvas, hudPos);

        
        
        //hudText.transform.position = hudPos.position;

        hudText.GetComponentInChildren<TextMeshProUGUI>().text = _text;
        hudText.GetComponentInChildren<TextMeshProUGUI>().color = c.HasValue ? c.Value : Color.white;




    }
}
