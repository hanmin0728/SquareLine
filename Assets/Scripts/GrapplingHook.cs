using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public LineRenderer line;
    public Transform hook;
    Vector2 mouseDir;
    /// <summary>
    /// eŰ �������� ���Ǵ� �����Ǵ°�
    /// </summary>
    public bool isHookActive; //�Һ����� ������� ������������ �ϴ±���
    public bool isLineMax;
    public bool isAttach;
    private void Start() {
        line.positionCount = 2; //������ �׸��� �������� �ΰ��� �����ϰ�
        line.endWidth = line.startWidth = 0.05f; //�̰� ũ��?
        line.SetPosition(0, transform.position); //�÷��̾� ������
        line.SetPosition(1, hook.position); // ������ hook�� ����������
        line.useWorldSpace = true; //������ǥ�� �������� ȭ�鿡 �׷����Ե�
        isAttach = false;
    }

    private void Update() {
        line.SetPosition(0, transform.position); //�÷��̾� ������
        line.SetPosition(1, hook.position); // ������ hook�� ����������


        //eŰ �������� ������ ���ϴ� �ڵ�
        if(Input.GetKeyDown(KeyCode.E) && !isHookActive) {
            hook.position = transform.position; //�÷��̾� ��ġ���� ���
            mouseDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            isHookActive = true;
            hook.gameObject.SetActive(true);
        }

        //�߻��ϴ� �ڵ�
        if(isHookActive && !isLineMax && !isAttach) {
            hook.Translate(mouseDir.normalized * Time.deltaTime * 15);
            //���� �̵��� Translate�� �Ѱ� 
            //��� �߻��ϴٰ� max�Ǹ� �׸��ΰ� �����߰�
            if(Vector2.Distance(transform.position, hook.position) > 5) {
                //DIstance�� �� �������� ���� �Ÿ��� �Ѱǰ�
                isLineMax = true;
            }
        }
        else if(isHookActive && isLineMax &&  !isAttach) {
            hook.position = Vector2.MoveTowards(hook.position, transform.position, Time.deltaTime * 15);
            if(Vector2.Distance(transform.position, hook.position) < 0.1f) {
                isHookActive = false; //Ʈ�簡 �Ǹ� �޽��� �Ǵ����ǵ� �������
                isLineMax = false;
                hook.gameObject.SetActive(false);
            }
        }
        else if(isAttach) {
            if(Input.GetKeyDown(KeyCode.E)) {
                isAttach = false;
                isHookActive = false; //���α׷��� ����帣�⸸ �ϴϱ� ���ǹ���
                isLineMax = false;
                hook.GetComponent<Ring>().joint2D.enabled = false;
                hook.gameObject.SetActive(false);
            }
          

        }
    }
}
