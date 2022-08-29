using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingMove : MonoBehaviour
{
    [SerializeField] public float verticalDistance; //수직 움직임.
    [SerializeField] public float horizontalDistance; //수평 움직임\

    [Range(0, 1)]
    [SerializeField] public float moveSpeed;

    Vector3 endPos1; //첫번쨰 목적지
    Vector3 endPos2; //두번째 목적지
    Vector3 currentDestination;

    private bool isUsed; // 훅에 사용됬나
    public bool IsUsed { get { return isUsed; } set { isUsed = value; } }

    private void Awake()
    {

    }
    private void Start()
    {

        RimgMovePosSet();
    }
    public void RingMoveZero()
    {
        currentDestination = Vector2.zero;
    }
    public void RimgMovePosSet()
    {
        Vector3 originPos = transform.position;
        endPos1.Set(originPos.x + horizontalDistance, originPos.y + verticalDistance, originPos.z);
        endPos2.Set(originPos.x - horizontalDistance, originPos.y - verticalDistance, originPos.z);
        currentDestination = endPos1;
    }

    private void Update()
    {

        if ((transform.position - endPos1).sqrMagnitude <= 0.2f) //Distance나 magintude는 매프레임마다에서는 성능상 불리함
        {
            //현재위치에서 -3만큼의 거리가 0.2f보다 작다? 
            //이말은 엔드포스까지 현재위치거리차이가 0.2f면 목적지 바꾸기

            currentDestination = endPos2;
        }
        else if ((transform.position - endPos2).sqrMagnitude <= 0.2f) //Distance나 magintude는 매프레임마다에서는 성능상 불리함
        {
            currentDestination = endPos1;
        }
        transform.position = Vector2.Lerp(transform.position, currentDestination, moveSpeed * Time.deltaTime);

    }


}

