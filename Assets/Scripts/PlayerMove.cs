using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    PlayerInput input;
    Rigidbody2D rigid;
    GrapplingHook grappling;
    PlayerAnimation anim;
    SpriteRenderer sprite;
    public float moveSpeed;
    public bool isJump;
    public bool isDown;

    public int jumpCount;
    public int currentCount;
    public int jumpForce;

    public int downForce;

    public float downDelay;
    private float downLastTime;


    // Start is called before the first frame update
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<PlayerAnimation>();
        currentCount = jumpCount;
        input = GetComponent<PlayerInput>();
        rigid = GetComponent<Rigidbody2D>();
        grappling = GetComponent<GrapplingHook>();
        downLastTime = Time.time;
    }



    // Update is called once per frame
    void Update()
    {
        if(input.isJump ) {
            isJump = true;
        }

        if(input.isDown && downDelay + downLastTime < Time.time) {
            downLastTime = Time.time;
            Debug.Log("�ٿ������");
            isDown = true;
        }
      

        float moveX = input.moveX;

        if(moveX < 0) {
            sprite.flipX = true;
        }
        else if(moveX > 0) {
            sprite.flipX = false;
        }
        //print(grappling.isAttach);
        if (grappling.isAttach) //�� ���� ���¸� �ҷε� �Ҽ��ֱ��� �׳� ���ǹ��� ���̳� �ݺ����� ��ųʸ��� �����������ϱ�
            rigid.AddForce(new Vector2(moveX * moveSpeed, 0));
        else
            rigid.velocity = (new Vector2(moveX * moveSpeed , rigid.velocity.y));


    }

    public int jumpCountis = 0;
    private void FixedUpdate() {
        
        if(isJump && currentCount > 0) {
            jumpCountis = 0;
            //FloatingManager.instance.TextMeshFloating($"����Ƚ��:{currentCount}!");
            FloatingManager.instance.TextMeshFloating("����!");
            currentCount--;
            rigid.velocity = Vector2.zero;
            rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.Jump();
        }
        else if(isJump) {
            if (jumpCountis < 6) {
                jumpCountis++;
                if (jumpCountis > 5) {

                    FloatingManager.instance.TextMeshFloating("�ƴ� �������Ѵٰ�..." , Color.red);
                } else {
               
                    FloatingManager.instance.TextMeshFloating("��������...");
                }
            }
          
        }
        isJump = false;
        
        if(isDown) {
            FloatingManager.instance.TextMeshFloating("�ް���!", Color.yellow);
            currentCount = 1;
            rigid.velocity = Vector2.zero;
            rigid.AddForce(Vector2.down * downForce, ForceMode2D.Impulse);
        }

        isDown = false;
    }
}
