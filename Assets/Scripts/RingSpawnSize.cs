using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RingSpawnSize : MonoBehaviour
{
    RectTransform _rectTransform;


    public float imageSizeX { //접근시 실행됨

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

        //사이즈를 구하고 
        // 그사이즈내에서 랜덤생성하고
        // 생성위치를 구한곳에서 원범위내에는 생성을 못하게 한다. 끝


        
    }

    public Vector2 GetScreenPosition(Vector2 pos ) {

        //127, 104
        //pos 
        return pos + _rectTransform.anchoredPosition;
    }
}
