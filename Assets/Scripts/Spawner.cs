using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner inst;
    RingSpawnSize ringSpawner;
    public GameObject prefabRing;
    public GameObject RingSign;
    SpriteRenderer circleSprtie;
 
    private float xRange;
    private float yRange;
    public int maxRingCount; //Ŭ����ȭ?
    public static int currentRingCount ;

    private bool isComplet;


    float scaleRing;
    float v;
    float h;
    float m;
    private void Awake() {
        inst = this;
    
    }


    private void Start() {
        currentRingCount = 0;
        ringSpawner = GameObject.Find("Image").GetComponent<RingSpawnSize>();
        circleSprtie = prefabRing.GetComponent<SpriteRenderer>();
        xRange = ringSpawner.imageSizeX;
        yRange = ringSpawner.ImageSizeY;
        StartCoroutine(Spawn());

        //Debug.Log($"{xRange}, {yRange}");

    }


    private void Update() {
     

        //��ȯ�Ҷ����� ī��Ʈ�� �÷����� �ƽ��� �Ǹ� ���̻� ����������
        // ���� �����ϸ� ����� �����Ŀ� 
        // �����ϸ� �� ī��Ʈ�÷�������

    }


    //����¡���̱��ϴ�
    public IEnumerator Spawn() {
        Camera mainCam = Camera.main;
        while (true) {


            yield return new WaitUntil(() => PoolManager.inst.isStart);
            if (currentRingCount >= maxRingCount) {
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

            Vector3 pos = mainCam.ScreenToWorldPoint(range);
            pos.z = 0;


            GameObject prefab = PoolManager.SpawnFromPool("RingSign", pos);
            previewSigh Sign = prefab.GetComponent<previewSigh>();
            // StopCoroutine(Sign.ColorToggle());
            int num = Random.Range(0, 3);
            switch (num) {
                case 0:
                case 1:
                case 3:
                num = 0;
                break;
                case 2:
                num = 1;
                break;
            }
            //������ �ٲ�ϱ� �׷����� �׷����������� �ٲ�� �ϳ�


            yield return StartCoroutine(Sign.ColorToggle(num));

            //�Ÿ���ũ��Ʈ�� �ڷ����� �����ͼ� �ϴ¹���̳� ���⿡�� �¾�� ���� �̸� �����شٰų�

            //�������� ������ ����� �¾ ������ �ϰų� 
            RingMove ringMove = null;

            //bool Com = false;
            //�����Ѱ����� ������ �Ҽ�����. �ۺ��� ����

            //����������ٷ�
            //�Ϸ�Ǳ⵵ ���� Ʈ�簡 �Ǳ⶧���ΰ�>?
            yield return new WaitUntil(() => prefab.GetComponent<previewSigh>().isColorComplet);
            //��������ο��� �������ָ� �ɵ�
            //�׸��� ����������� ��äȭ�ؼ� ������ �����ұ�?
            //�����ϴ� ���ӿ�����Ʈ�� �ϰ��ϸ� ����������?

            //�̰� ����ǥ�ÿ��� �����ϰ� �Ϸ��� ���� �ұ�?

            currentRingCount++;
            GameObject ringPre = PoolManager.SpawnFromPool("Ring", pos); //���⸦ GameObjectName����
            scaleRing = Random.Range(0.4f, 1f);
            //public �� �����غ��߰ڴ�
            HookRing hookRing = ringPre.GetComponent<HookRing>();
            hookRing.RingScaleSet(scaleRing);

            ringMove = ringPre.GetComponent<RingMove>();

            //���ڸ��� ���������� �ְ�
            //
            SetDistance(ringMove, num);


        }




    }

    //1�̸� �̷��� ���� 0�����ϴ°͵� ����̱���
    //  �̷��� �ϸ�Ǵ±���

    //�̰� �����꿡 �Ȱܰ����� 
    public void SetDistance(RingMove ringMove, int num) { //�̰͵� ���ʿ��� ����?

        v = Random.Range(1f, 4f);
        h = Random.Range(1f, 4f);
        m = Random.Range(0.7f, 1f);

        if (num == 0) {
            ringMove.verticalDistance = 0;
            ringMove.horizontalDistance = 0; //���Լ������� �ٲٰ� �ϴ� �� ��
            ringMove.moveSpeed = 0;
            ringMove.RimgMovePosSet();
            ringMove.RingMoveZero();
        }
        if (ringMove != null && num == 1) {
            //print("��?");
            //�ٵ� �̰� ������ �ƴҰ�쿡��?
            ringMove.verticalDistance = v;
            ringMove.horizontalDistance = h; //���Լ������� �ٲٰ� �ϴ� �� ��
            ringMove.moveSpeed = m;



            ringMove.RimgMovePosSet();
        }
    }
    private void FixedUpdate() {
        //�̷��ϱ� ������Ʈ�� ������ ������Ʈ������ �ڷ�ƾ�Ҽ��ְ� �ؾߵǳ�?

    }



}
