using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public LineRenderer line;
    public Transform hook;
    Vector2 mouseDir;
    /// <summary>
    /// e키 눌렀을떄 참또는 거짓되는거
    /// </summary>
    public bool isHookActive; //불변수로 어떤조건이 만족했을떄를 하는구나
    public bool isLineMax;
    public bool isAttach;
    private void Start() {
        line.positionCount = 2; //라인을 그리는 포지션을 두개로 설정하고
        line.endWidth = line.startWidth = 0.05f; //이게 크기?
        line.SetPosition(0, transform.position); //플레이어 포지션
        line.SetPosition(1, hook.position); // 한점은 hook의 포지션으로
        line.useWorldSpace = true; //월드좌표를 기준으로 화면에 그려지게됨
        isAttach = false;
    }

    private void Update() {
        line.SetPosition(0, transform.position); //플레이어 포지션
        line.SetPosition(1, hook.position); // 한점은 hook의 포지션으로


        //e키 눌렀을떄 방향을 구하는 코드
        if(Input.GetKeyDown(KeyCode.E) && !isHookActive) {
            hook.position = transform.position; //플레이어 위치에서 출발
            mouseDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            isHookActive = true;
            hook.gameObject.SetActive(true);
        }

        //발사하는 코드
        if(isHookActive && !isLineMax && !isAttach) {
            hook.Translate(mouseDir.normalized * Time.deltaTime * 15);
            //훅의 이동을 Translate로 한것 
            //계속 발사하다가 max되면 그만두게 조건추가
            if(Vector2.Distance(transform.position, hook.position) > 5) {
                //DIstance가 두 포지션의 값을 거리로 한건가
                isLineMax = true;
            }
        }
        else if(isHookActive && isLineMax &&  !isAttach) {
            hook.position = Vector2.MoveTowards(hook.position, transform.position, Time.deltaTime * 15);
            if(Vector2.Distance(transform.position, hook.position) < 0.1f) {
                isHookActive = false; //트루가 되면 펄스가 되는조건도 만들어줌
                isLineMax = false;
                hook.gameObject.SetActive(false);
            }
        }
        else if(isAttach) {
            if(Input.GetKeyDown(KeyCode.E)) {
                isAttach = false;
                isHookActive = false; //프로그램은 계속흐르기만 하니까 조건문이
                isLineMax = false;
                hook.GetComponent<Ring>().joint2D.enabled = false;
                hook.gameObject.SetActive(false);
            }
          

        }
    }
}
