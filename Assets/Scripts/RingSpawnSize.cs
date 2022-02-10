using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RingSpawnSize : MonoBehaviour
{
    RectTransform _rectTransform;


    public float imageSizeX { //���ٽ� �����

        get {
            if (_rectTransform == null)
                _rectTransform = GetComponent<RectTransform>();

           //Debug.Log( _rectTransform.sizeDelta.x);
            return _rectTransform.sizeDelta.x;

        }

    }

   
    public float ImageSizeY {
        get {
            if (_rectTransform == null)
                _rectTransform = GetComponent<RectTransform>();

            //Debug.Log(_rectTransform.sizeDelta.y);
            return _rectTransform.sizeDelta.y;

        }

    }


    private void Start() {

        //����� ���ϰ� 
        // �׻�������� ���������ϰ�
        // ������ġ�� ���Ѱ����� ������������ ������ ���ϰ� �Ѵ�. ��


        
    }

    public Vector2 GetScreenPosition(Vector2 pos ) {

        //127, 104
        //pos 
        return pos + _rectTransform.anchoredPosition;
    }
}
