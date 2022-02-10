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
    public ParticleSystem particleSystem;
    public ParticleSystem downParticle;
    //public ParticleSet particleSet;
    public Transform downPos;
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

        if ((moveX > 0 && !facingRight) || (moveX < 0 && facingRight))
            Flip();
        //print(grappling.isAttach);
        if (grappling.isAttach) //�� ���� ���¸� �ҷε� �Ҽ��ֱ��� �׳� ���ǹ��� ���̳� �ݺ����� ��ųʸ��� �����������ϱ�
            rigid.AddForce(new Vector2(moveX * moveSpeed, 0));
        else
            rigid.velocity = (new Vector2(moveX * moveSpeed , rigid.velocity.y));


    }

    public int jumpCountis = 0;

    [Header("��������")]

    public bool facingRight;
    private void Flip() {
        facingRight = !facingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    bool isDownParticle;
    private void FixedUpdate() {



        if (isJump && currentCount > 0) {

            particleSystem.transform.position = transform.position;

            particleSystem.Play();
            transform.rotation = Quaternion.Euler(0, 0, 0);
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
            isDownParticle = true;
            FloatingManager.instance.TextMeshFloating("�ް���!", Color.yellow);
            currentCount = 1;
            rigid.velocity = Vector2.zero;
            rigid.AddForce(Vector2.down * downForce, ForceMode2D.Impulse);
        }

        isDown = false;


        if(rigid.velocity.y < -20 && isDownParticle) {
            isDownParticle = false;
            Vector3 pos = transform.position;
            downParticle.transform.position = downPos.position;
            //downParticle.transform.Translate(Vector2.down * 10);
            //downParticle.transform.localPosition *= Vector2.down * 1; 
            downParticle.Play();
        }
    }
}
