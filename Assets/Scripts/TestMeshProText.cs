using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestMeshProText : MonoBehaviour
{
    public float moveSpeed; //텍스트 이동속도
    public float alphaSpeed; //투명도 변환속도
    public float destroyTime;
    TextMeshProUGUI text;
    Color alpha;

    private void Start() {
        text = GetComponent<TextMeshProUGUI>();
        alpha = text.color;
        Invoke("DestroyObjet", destroyTime);
    }

    private void Update() {
        transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0));
        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed); //a에서 b까지 , 시간동안
        text.color = alpha;
    }

    private void DestroyObjet() {
        Destroy(gameObject);
    }


}
