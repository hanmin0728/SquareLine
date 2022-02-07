using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    GrapplingHook grappling;
    public DistanceJoint2D joint2D;

    private void Start() {
        grappling = GameObject.Find("Player").GetComponent<GrapplingHook>();
        joint2D = GetComponent<DistanceJoint2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Ring")) {
            joint2D.enabled = true; //프로그래밍은 활용과 검색능력이구만
            grappling.isAttach = true;
            //조인트를 모른채 구현했다면 ㄷㄷ
        }
    }
}
