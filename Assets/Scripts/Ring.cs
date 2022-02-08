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

            int Randnum = Random.Range(1, 7); //������ �������� �ְ� �ٻ�������� 


            joint2D.enabled = true; //���α׷����� Ȱ��� �˻��ɷ��̱���
            grappling.isAttach = true;


            //ù������ ������ ������Ű�� 
            // ������� ���ְ� �ϰ� 
            // �ѹ���� ����������� ������ 2�ϱ� �׶��� ����ȵǰ�?
            collision.gameObject.GetComponent<SpriteRenderer>().material.DOFade(0, 3).OnComplete(()=> {
                currentTouchRing--;

                collision.gameObject.SetActive(false);

                Spawner.currentRingCount--;
         
                //ù��°�� ��Ҵ��� ������ ����ִٴ� ��� �ұ�?
                // ������ ������ ���ڸ� �ο��ϰ� �׼��ڶ� ������ ? 



                if(grappling.isAttach && currentTouchRing < 1) {
                    grappling.isAttach = false;
                    grappling.isHookActive = false;
                    grappling.isLineMax = false;
                    joint2D.enabled = false;
                    grappling.hook.gameObject.SetActive(false);
                }
            });
            //����Ʈ�� ��ä �����ߴٸ� ����
        }
    }
}
