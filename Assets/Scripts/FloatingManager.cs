using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingManager : MonoBehaviour
{
    public static FloatingManager instance;

    public Transform hudPos; 
    public GameObject hudTextMeshCanvas; //���⿡ �ؽ�Ʈ�޽�����
    
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
        //print("color��?" + (c.HasValue ? c.Value : Color.white));
        hudText.GetComponentInChildren<TextMeshProUGUI>().color = c.HasValue ? c.Value : Color.white;
        //print("�ؽ�Ʈ�� �÷���?" + hudText.GetComponentInChildren<TextMeshProUGUI>().color);


        TestMeshProText test = hudText.GetComponentInChildren<TestMeshProText>();
        test.SetColor(hudText.GetComponentInChildren<TextMeshProUGUI>().color);
        //�̰Կ����� ������ �θ� �ִ� ���¿��� �������� �������־��� ������ �׷�����

        hudText.transform.position =   currentPos.position; //���ӸŴ����� �޵�����



    }

    
}
