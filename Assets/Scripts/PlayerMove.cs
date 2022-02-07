using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    PlayerInput input;
    Rigidbody2D rigid;
    GrapplingHook grappling;

    public float moveSpeed;
    private bool isJump;
    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<PlayerInput>();
        rigid = GetComponent<Rigidbody2D>();
        grappling = GetComponent<GrapplingHook>();
    }

    // Update is called once per frame
    void Update()
    {
        if(input.isJump) {
            isJump = true;
        }

        float moveX = input.moveX;

        //print(grappling.isAttach);
        if (grappling.isAttach) //아 붙은 상태를 불로도 할수있구나 그냥 조건문이 답이네 반복문도 딕셔너리도 쓸수있을때니까
            rigid.AddForce(new Vector2(moveX * moveSpeed, 0));
        else
            rigid.velocity = (new Vector2(moveX * moveSpeed , rigid.velocity.y));


    }

    private void FixedUpdate() {
        
        if(isJump) {
            rigid.velocity = Vector2.zero;
            rigid.AddForce(Vector2.up * 10 , ForceMode2D.Impulse);
        }

        isJump = false;
    }
}
