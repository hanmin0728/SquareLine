using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;
    PlayerInput input;
    Rigidbody2D rigid;

    readonly int hashJump = Animator.StringToHash("Jumping");
    private readonly int hashYSpeed = Animator.StringToHash("ySpeed");

    private void Awake() {
        anim = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        float xMove = input.moveX;
        anim.SetFloat("xMove", Mathf.Abs(xMove));

        anim.SetFloat(hashYSpeed, rigid.velocity.y);


    }


    public void Jump() {
        anim.SetTrigger(hashJump);
    }

    public void Hook(bool isHook) {
        anim.SetBool("Hook", isHook);

    }
}
