using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookRing : MonoBehaviour
{

    private void OnEnable() {

        //Invoke(nameof(TimeAram), 7f);
        //Invoke(nameof(SetActicve), 10f);

        //�̰������� ���� ���� �ϴϱ� ������ �ȵȴ���?
    }

    void TimeAram() {
        FloatingManager.instance.TextMeshFloating("3����", Color.white, transform);
    }

    void SetActicve() {
        FloatingManager.instance.TextMeshFloating("�ð��� �ʹ� ������",Color.white ,transform);
        gameObject.SetActive(false);
    }

    public void RingScaleSet(float scale) {

        transform.localScale = new Vector3(scale, scale, 1);
    }
    private void OnDisable() {
        //print("��������");
        PoolManager.ReturnToPool(gameObject);
        CancelInvoke();
    }

    //��ȯ�Ǵ°Ŷ� �����̴°� ������ ����� ����������?





}
