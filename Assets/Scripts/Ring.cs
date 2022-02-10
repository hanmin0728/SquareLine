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
            int Randnum = Random.Range(1, 7); //������ �������� �ְ� �ٻ�������� 


            joint2D.enabled = true; //���α׷����� Ȱ��� �˻��ɷ��̱���
            grappling.isAttach = true;
            Spawner.currentRingCount--;

            StartCoroutine(RingMoveToward(collision));
            //ù������ ������ ������Ű�� 
            // ������� ���ְ� �ϰ� 
            // �ѹ���� ����������� ������ 2�ϱ� �׶��� ����ȵǰ�?
      
            collision.gameObject.GetComponent<SpriteRenderer>().material.DOFade(0, 1.5f).OnComplete(()=> {
                currentTouchRing--;

                collision.gameObject.SetActive(false);

             
         
                //ù��°�� ��Ҵ��� ������ ����ִٴ� ��� �ұ�?
                // ������ ������ ���ڸ� �ο��ϰ� �׼��ڶ� ������ ? 



                if(grappling.isAttach && currentTouchRing < 1) {
                    FloatingManager.instance.TextMeshFloating("�ð��ʰ�!", Color.yellow);
                    grappling.isAttach = false;
                    grappling.isHookActive = false;
                    grappling.isLineMax = false;
                    joint2D.enabled = false;
                    grappling.hook.gameObject.SetActive(false);
                }
                isCompltColor = true;
                //OnComplit�ɶ����� �������δ� ���Ѿ��? �ƴϳ� �׳� ����ǳ�
            });

            //Debug.Log("OnComplet�Ϸ�");
            //����Ʈ�� ��ä �����ߴٸ� ����
            //StopCoroutine(RingMoveToward(collision)); �̰��ʿ��ϳ� ��� �ߵǱ� �ϴµ�
        }
    }

    IEnumerator RingMoveToward(Collider2D collision) { //������ϱ�
        while (true) 
        {
            grappling.hook.position = collision.transform.position; //�̰ɹݺ��ǰ�
            yield return null;
        }
        
    }
}
