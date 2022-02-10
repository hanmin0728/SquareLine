using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class previewSigh : MonoBehaviour {
    //�ٸ���ü������ �Ҽ��ְ� �������̽���?
    SpriteRenderer sprite;
   
    public Color[] colorSet = new Color[2];
    int idx = 0;
    public bool isColorComplet = false;
    private void Awake() {
        sprite = GetComponent<SpriteRenderer>();
    }

    //�ø��������� �Ŵ�����?
    [Serializable]
    public class SignColor {
        public string name;
        public int num;
        public Color[] color;
    }
    [SerializeField] SignColor[] sings;
    //���⿡�� ������ �ƴ� �ܺη� ����?

    //���⼭ ����ȭ�ذ����� ��ȣ�� ����? �� �ϸ� ���� ������?
    //hookRing�� RingMove�� �����ͼ� ���� �ƴ϶�� 
    //�׸��� ���� �ٲٰ�

    
    public IEnumerator ColorToggle(int num = 0) {



        //�̰� ���� Enum���� �ϸ� �����ϳ�? ���α׷����Ҷ��� �ڿ���� ���α׷����غ��� �ڿ��� ���ٸ��� �����غ��¼��ۿ� ������
        //���� ������ ���ͳ� �˻��ؼ� �ذ��ϴ� ����� ������ �̋� �˰����� �����ذ����� �˻��̳� �ڷᱸ�������ɷ� �ϴ°ű��� ���е� �׷��� 


   
        switch (num) {
            case 0:
            colorSet = sings[num].color; //�̰͵� ���ں��ٴ� �Ŵ����� �ذ����� �̸��� ������ �׻��� �°� �ؾ߰ڴ�.
           
            break;
            case 1:
            colorSet = sings[num].color; 
            break;
            case 2:
            colorSet = sings[num].color;
            break;

        }

  

        for (int i = 0; i < 4; i++) {

            sprite.color = colorSet[0];
            yield return new WaitForSeconds(0.15f);
            sprite.color = colorSet[1];
            yield return new WaitForSeconds(0.15f);

        }


        isColorComplet = true;

        gameObject.SetActive(false);

        //�ҷ� �ϴ¹���̶� �Լ��� �̰� �޾ư����� �̰��ϴ¹��
    }


    private void OnDisable() {
        PoolManager.ReturnToPool(gameObject);

    }
}
