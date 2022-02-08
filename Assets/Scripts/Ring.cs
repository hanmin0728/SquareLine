using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ring : MonoBehaviour
{
    PlayerMove move;
    GrapplingHook grappling;
    public DistanceJoint2D joint2D;

    public int currentTouchRing = 0;
    private void Start() {
        
        grappling = GameObject.Find("Player").GetComponent<GrapplingHook>();
        joint2D = GetComponent<DistanceJoint2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Ring")) {
            currentTouchRing++;

            int Randnum = Random.Range(1, 7); //닿으면 랜덤값을 주고 다사라졌을떄 


            joint2D.enabled = true; //프로그래밍은 활용과 검색능력이구만
            grappling.isAttach = true;


            //첫번쨰로 닿으면 증가시키고 
            // 사라지면 없애게 하고 
            // 한번닿고 사라지기전에 닿으면 2니까 그때는 실행안되게?
            collision.gameObject.GetComponent<SpriteRenderer>().material.DOFade(0, 3).OnComplete(()=> {
                currentTouchRing--;

                collision.gameObject.SetActive(false);

                Spawner.currentRingCount--;
         
                //첫번째로 닿았던게 아직도 닿아있다는 어떻게 할까?
                // 생성된 원마다 숫자를 부여하고 그숫자랑 같으면 ? 



                if(grappling.isAttach && currentTouchRing < 1) {
                    grappling.isAttach = false;
                    grappling.isHookActive = false;
                    grappling.isLineMax = false;
                    joint2D.enabled = false;
                    grappling.hook.gameObject.SetActive(false);
                }
            });
            //조인트를 모른채 구현했다면 ㄷㄷ
        }
    }
}
