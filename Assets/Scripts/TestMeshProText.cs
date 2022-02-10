using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestMeshProText : MonoBehaviour {
    public float moveSpeed; //�ؽ�Ʈ �̵��ӵ�
    public float alphaSpeed; //���� ��ȯ�ӵ�

    public float destroyTime;

    TextMeshProUGUI text;
    Color alpha;

    private void OnEnable() {
        text = GetComponent<TextMeshProUGUI>();

        
        alpha = text.color;


        Invoke("DestroyObject", destroyTime);

    }
    void DestroyObject() {
        gameObject.SetActive(false);
    }
    private void Update() {
        transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0));
        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed); //a���� b���� , �ð�����
        text.color = alpha;
    }

    public void SetColor(Color c) {
        

        text.color = c;
    }


}
