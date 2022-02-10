using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BackGroundMove : MonoBehaviour
{
    SpriteRenderer spriteRender;
    public float yPos;
    public float yPosDown;
    public float xPos;
    public float xPosDown;
    public float UpTime;
    public float DownTime;
    void Start()
    {
        spriteRender = GetComponentInChildren<SpriteRenderer>();
    }


    public bool isMove = false;

    public bool isMoveSet;
    public bool isScaleSet;
    // Update is called once per frame
    void Update()
    {
        if(isMoveSet) {
            if (!isMove) {

                transform.DOMove(new Vector2(xPos, yPos), UpTime).OnComplete(() => isMove = true);
            } else if (isMove) {
                transform.DOMove(new Vector2(xPosDown, yPosDown), DownTime).OnComplete(() => isMove = false);
            }
        }
        
        if(isScaleSet) {
            if (!isMove) {

                transform.DOScaleX(xPos, UpTime).OnComplete(() => isMove = true);
            } else if (isMove) {
                transform.DOScaleX(xPosDown, DownTime).OnComplete(() => isMove = false);
            }
        }

    }
}
