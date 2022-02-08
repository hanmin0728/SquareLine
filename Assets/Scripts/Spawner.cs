using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    RingSpawner ringSpawner;
    public GameObject prefabRing;
    public GameObject RingSign;
    SpriteRenderer circleSprtie;
 
    private float xRange;
    private float yRange;
    public int maxRingCount; //Ŭ����ȭ?
    public static int currentRingCount ;

    private bool isComplet;
    private void Start() {
        currentRingCount = 0;
        ringSpawner = GameObject.Find("Image").GetComponent<RingSpawner>();
        circleSprtie = prefabRing.GetComponent<SpriteRenderer>();
        xRange = ringSpawner.imageSizeX;
        yRange = ringSpawner.ImageSizeY;
        StartCoroutine(Spawn());

        Debug.Log($"{xRange}, {yRange}");
        
    }


    private void Update() {
     

        //��ȯ�Ҷ����� ī��Ʈ�� �÷����� �ƽ��� �Ǹ� ���̻� ����������
        // ���� �����ϸ� ����� �����Ŀ� 
        // �����ϸ� �� ī��Ʈ�÷�������

    }

    private IEnumerator Spawn() {
        Camera mainCam = Camera.main;
        while(true) {

            if(currentRingCount >= maxRingCount) {
                yield return null;
                continue;
            }

            float x = Random.Range(0 + circleSprtie.bounds.size.x, xRange - circleSprtie.bounds.size.x); //1665.87 0�̶� �̹����� posX , PosY
            
            float y = Random.Range(0 + circleSprtie.bounds.size.x, yRange - circleSprtie.bounds.size.x); //870.0401
            Vector3 range = new Vector3(x, y, mainCam.nearClipPlane);//�������
            range = ringSpawner.GetScreenPosition(range); //new Vector2(pos.x + 1670 , pos.y + 870)
            //�ּҿ��� ���ϰ� 
            // �ִ뿡�� ���ߵǴµ� 
            // x ���̻��̸� 
            // 127 + 104 


           // Debug.Log(range);
            Vector3 pos = mainCam.ScreenToWorldPoint(range);
            pos.z = 0;

            //���⿡�� �̹� ��Ÿ�� ��ġ�� �������ϱ� ���⿡�� ����ǥ���ϴ� �̹���? ����Ʈ�ϸ� ����

            //Instantiate(RingSign, pos, Quaternion.identity);

            //��ӹ߻��Ϸ���?
            GameObject prefab = Instantiate(RingSign, pos, Quaternion.identity);

            currentRingCount++;

            Instantiate(prefabRing, pos, Quaternion.identity);

       
           
            //findObject Cmaera.main
            yield return new WaitForSeconds(0.3f);
            //�����ҋ� �̸� �˷��ִ� ǥ��?

        }
        
    }



    private void FixedUpdate() {
        //�̷��ϱ� ������Ʈ�� ������ ������Ʈ������ �ڷ�ƾ�Ҽ��ְ� �ؾߵǳ�?

    }



}
