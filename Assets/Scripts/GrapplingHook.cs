using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public LineRenderer line;
    public Transform hook;
    PlayerInput input;
    PlayerMove move;
    Vector2 mouseDir;
    /// <summary>
    /// eŰ �������� ���Ǵ� �����Ǵ°�
    /// </summary>
    public bool isHookActive; //�Һ����� ������� ������������ �ϴ±���
    public bool isLineMax;
    public bool isAttach;
    [Header("�Ž��ǵ�")]
    public float hookSpeed;
    [Header("�ű���")]
    public float hootMax;

    private bool isJump;
    private bool isMouse;

    private float hookLastTime;
    public float hookDelay;

    private float reHookLastTime;
    public float reHookDelay;
   
    private void Awake() {
        input = GetComponent<PlayerInput>();
        move = GetComponent<PlayerMove>();
    }

    private void Start() {
        hookLastTime = Time.time;
        reHookLastTime = Time.time;
        line.positionCount = 2; //������ �׸��� �������� �ΰ��� �����ϰ�
        line.endWidth = line.startWidth = 0.05f; //�̰� ũ��?
        line.SetPosition(0, transform.position); //�÷��̾� ������
        line.SetPosition(1, hook.position); // ������ hook�� ����������
        line.useWorldSpace = true; //������ǥ�� �������� ȭ�鿡 �׷����Ե�
        isAttach = false;
    }

    private void Update() {
        if(input.isJump) {
            isJump = true; //�÷��̾�꿡 ����������?
        }

        if(input.isMouse && hookDelay + hookLastTime < Time.time) {
            hookLastTime = Time.time;
            isMouse = true;
        }
        line.SetPosition(0, transform.position); //�÷��̾� ������
        line.SetPosition(1, hook.position); // ������ hook�� ����������



        //eŰ �������� ������ ���ϴ� �ڵ�

    }

    private void FixedUpdate() {
        if (isMouse && !isHookActive) {
            hook.position = transform.position; //�÷��̾� ��ġ���� ���
            mouseDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            isHookActive = true;
            hook.gameObject.SetActive(true);
        }

        //�߻��ϴ� �ڵ�
        if (isHookActive && !isLineMax && !isAttach) {
            reHookLastTime = Time.time;
            hook.Translate(mouseDir.normalized * Time.deltaTime * hookSpeed);
            //���� �̵��� Translate�� �Ѱ� 
            //��� �߻��ϴٰ� max�Ǹ� �׸��ΰ� �����߰�
            if (Vector2.Distance(transform.position, hook.position) > hootMax) {
                //DIstance�� �� �������� ���� �Ÿ��� �Ѱǰ�
                isLineMax = true;
            }
        }
        //�ִ�ũ��� ���ƿ��� �ڵ�
        else if (isHookActive && isLineMax && !isAttach) {
            hook.position = Vector2.MoveTowards(hook.position, transform.position, Time.deltaTime * hookSpeed);
            if (Vector2.Distance(transform.position, hook.position) < 0.1f) {
                isHookActive = false; //Ʈ�簡 �Ǹ� �޽��� �Ǵ����ǵ� �������
                isLineMax = false;
                hook.gameObject.SetActive(false);
            }
        } else if (isAttach ) {

            move.currentCount = move.jumpCount;
            if (reHookLastTime + reHookDelay < Time.time && (isMouse || isJump)) {

                reHookLastTime = Time.time;
                isAttach = false;
                isHookActive = false; //���α׷��� ����帣�⸸ �ϴϱ� ���ǹ���
                isLineMax = false;
                hook.GetComponent<Ring>().joint2D.enabled = false;
                hook.gameObject.SetActive(false);
            }


        }

        isJump = false;
        isMouse = false;
    }
 
}
