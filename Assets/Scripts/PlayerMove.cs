using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    PlayerInput input;
    Rigidbody2D rigid;
    GrapplingHook grappling;

    public float moveSpeed;
    public bool isJump;

    public int jumpCount;
    public int currentCount;
    // Start is called before the first frame update
    void Start()
    {
        currentCount = jumpCount;
        input = GetComponent<PlayerInput>();
        rigid = GetComponent<Rigidbody2D>();
        grappling = GetComponent<GrapplingHook>();
    }

    // Update is called once per frame
    void Update()
    {
        if(input.isJump ) {
            isJump = true;
        }

        float moveX = input.moveX;

        //print(grappling.isAttach);
        if (grappling.isAttach) //�� ���� ���¸� �ҷε� �Ҽ��ֱ��� �׳� ���ǹ��� ���̳� �ݺ����� ��ųʸ��� �����������ϱ�
            rigid.AddForce(new Vector2(moveX * moveSpeed, 0));
        else
            rigid.velocity = (new Vector2(moveX * moveSpeed , rigid.velocity.y));


    }

    private void FixedUpdate() {
        
        if(isJump && currentCount > 0) {
            currentCount--;
            rigid.velocity = Vector2.zero;
            rigid.AddForce(Vector2.up * 10 , ForceMode2D.Impulse);
        }
        isJump = false;
        

    }
}
