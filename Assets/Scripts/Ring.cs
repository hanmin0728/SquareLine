using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ring : MonoBehaviour
{
    PlayerMove move;
    GrapplingHook grappling;
    public DistanceJoint2D joint2D;

    private bool isCompltColor = false;
    public int currentTouchRing = 0;
    private void Start() {
        
        grappling = GameObject.Find("Player").GetComponent<GrapplingHook>();
        joint2D = GetComponent<DistanceJoint2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Ring")) {
            //CancelInvoke();
            currentTouchRing++;
            //grappling.hook.position
            int Randnum = Random.Range(1, 7); //닿으면 랜덤값을 주고 다사라졌을떄 


            joint2D.enabled = true; //프로그래밍은 활용과 검색능력이구만
            grappling.isAttach = true;
            Spawner.currentRingCount--;

            StartCoroutine(RingMoveToward(collision));
            //첫번쨰로 닿으면 증가시키고 
            // 사라지면 없애게 하고 
            // 한번닿고 사라지기전에 닿으면 2니까 그때는 실행안되게?
      
            collision.gameObject.GetComponent<SpriteRenderer>().material.DOFade(0, 1.5f).OnComplete(()=> {
                currentTouchRing--;

                collision.gameObject.SetActive(false);

             
         
                //첫번째로 닿았던게 아직도 닿아있다는 어떻게 할까?
                // 생성된 원마다 숫자를 부여하고 그숫자랑 같으면 ? 



                if(grappling.isAttach && currentTouchRing < 1) {
                    FloatingManager.instance.TextMeshFloating("시간초과!", Color.yellow);
                    grappling.isAttach = false;
                    grappling.isHookActive = false;
                    grappling.isLineMax = false;
                    joint2D.enabled = false;
                    grappling.hook.gameObject.SetActive(false);
                }
                isCompltColor = true;
                //OnComplit될때까지 다음으로는 못넘어가나? 아니네 그냥 실행되네
            });

            //Debug.Log("OnComplet완료");
            //조인트를 모른채 구현했다면 ㄷㄷ
            //StopCoroutine(RingMoveToward(collision)); 이거필요하나 없어도 잘되긴 하는데
        }
    }

    IEnumerator RingMoveToward(Collider2D collision) { //스레드니까
        while (true) 
        {
            grappling.hook.position = collision.transform.position; //이걸반복되게
            yield return null;
        }
        
    }
}
