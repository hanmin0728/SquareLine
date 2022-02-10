using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingMove : MonoBehaviour {
    [SerializeField] public float verticalDistance; //���� ������.
    [SerializeField] public float horizontalDistance; //���� ������\

    [Range(0, 1)]
    [SerializeField] public float moveSpeed;

    Vector3 endPos1; //ù���� ������
    Vector3 endPos2; //�ι�° ������
    Vector3 currentDestination;

    private void Awake() {

    }
    private void Start() {
        
        Vector3 originPos = transform.position; //������ġ ����
        //������ġ���� ����ŭ y���� ����ŭ �̸� ����
        endPos1.Set(originPos.x + horizontalDistance, originPos.y + verticalDistance, originPos.z);
        endPos2.Set(originPos.x - horizontalDistance, originPos.y - verticalDistance, originPos.z);
        currentDestination = endPos1;
    }


    private void Update() {

        //Debug.Log("������");
        if ((transform.position - endPos1).sqrMagnitude <= 0.2f) //Distance�� magintude�� �������Ӹ��ٿ����� ���ɻ� �Ҹ���
        {
            //������ġ���� -3��ŭ�� �Ÿ��� 0.2f���� �۴�? 
            //�̸��� ������������ ������ġ�Ÿ����̰� 0.2f�� ������ �ٲٱ�

            currentDestination = endPos2;
        } else if ((transform.position - endPos2).sqrMagnitude <= 0.2f) //Distance�� magintude�� �������Ӹ��ٿ����� ���ɻ� �Ҹ���
          {
            currentDestination = endPos1;
        }
        transform.position = Vector2.Lerp(transform.position, currentDestination, moveSpeed * Time.deltaTime);

    }


}

