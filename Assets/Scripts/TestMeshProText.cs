using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestMeshProText : MonoBehaviour
{
    public float moveSpeed; //�ؽ�Ʈ �̵��ӵ�
    public float alphaSpeed; //���� ��ȯ�ӵ�
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
        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed); //a���� b���� , �ð�����
        text.color = alpha;
    }

    private void DestroyObjet() {
        Destroy(gameObject);
    }


}
