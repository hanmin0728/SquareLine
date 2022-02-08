using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookRing : MonoBehaviour
{

    float scaleRing;
    float v;
    float h;
    float m;

    RingMove ringMove;

    private void OnEnable() {

        int num = Random.Range(0, 3);
        switch(num) {
            case 0:
            case 1:
            ringMove = null;
            break;
            case 2:
            ringMove = GetComponent<RingMove>();
            break;
        }
        scaleRing = Random.Range(0.4f, 1f);
        transform.localScale = new Vector3(scaleRing, scaleRing, 1);

        v = Random.Range(0, 4f);
        h = Random.Range(0, 4f);
        m = Random.Range(0.7f, 1f);
        if (ringMove !=null) {
            ringMove.verticalDistance = v;
            ringMove.horizontalDistance = h;
            ringMove.moveSpeed = m;
        }

    }



        //소환되는거랑 깜박이는걸 별개로 만들면 되지않을까?

    



}
