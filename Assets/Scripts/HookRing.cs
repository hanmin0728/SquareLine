using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookRing : MonoBehaviour
{

    private void OnEnable() {

        //Invoke(nameof(TimeAram), 7f);
        //Invoke(nameof(SetActicve), 10f);

        //이거이유가 뭐지 저거 하니까 생성이 안된느데?
    }

    void TimeAram() {
        FloatingManager.instance.TextMeshFloating("3초전", Color.white, transform);
    }

    void SetActicve() {
        FloatingManager.instance.TextMeshFloating("시간이 너무 오래됨",Color.white ,transform);
        gameObject.SetActive(false);
    }

    public void RingScaleSet(float scale) {

        transform.localScale = new Vector3(scale, scale, 1);
    }
    private void OnDisable() {
        //print("ㅇㄴㄴㅇ");
        PoolManager.ReturnToPool(gameObject);
        CancelInvoke();
    }

    //소환되는거랑 깜박이는걸 별개로 만들면 되지않을까?





}
