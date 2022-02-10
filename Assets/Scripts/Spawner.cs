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
    public int maxRingCount; //클래스화?
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
     

        //소환할때마다 카운트가 플러스되 맥스가 되면 더이상 생성하지마
        // 훅이 명중하면 사라져 몇초후에 
        // 생성하면 또 카운트플러스가되

    }


    //엉망징찬이긴하다
    public IEnumerator Spawn() {
        Camera mainCam = Camera.main;
        while (true) {


            yield return new WaitUntil(() => PoolManager.inst.isStart);
            if (currentRingCount >= maxRingCount) {
                yield return null;
                continue;
            }
            float x = Random.Range(0 + circleSprtie.bounds.size.x, xRange - circleSprtie.bounds.size.x); //1665.87 0이라서 이미지의 posX , PosY

            float y = Random.Range(0 + circleSprtie.bounds.size.x, yRange - circleSprtie.bounds.size.x); //870.0401
            Vector3 range = new Vector3(x, y, mainCam.nearClipPlane);//오버헤드
            range = ringSpawner.GetScreenPosition(range); //new Vector2(pos.x + 1670 , pos.y + 870)
                                                          //최소에선 더하고 
                                                          // 최대에선 뺴야되는데 
                                                          // x 반이상이면 
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
            //순간에 바뀌니까 그렇구만 그럼마지막에도 바꿔야 하네


            yield return StartCoroutine(Sign.ColorToggle(num));

            //훅링스크립트나 자료형을 가져와서 하는방법이나 여기에서 태어나는 것을 미리 정해준다거나

            //독립성을 가지는 방법은 태어난 곳에서 하거나 
            RingMove ringMove = null;

            //bool Com = false;
            //생성한곳에서 독립을 할수있음. 퍼블릭은 실험

            //실행시점스바루
            //완료되기도 전에 트루가 되기때문인가>?
            yield return new WaitUntil(() => prefab.GetComponent<previewSigh>().isColorComplet);
            //프리뷰사인에서 생성해주면 될듯
            //그리고 프리뷰사인을 객채화해서 쓸려면 어케할까?
            //생성하는 게임오브젝트를 하고하면 되지않을ㄲ?

            //이걸 범위표시에서 생성하게 하려면 어케 할까?

            currentRingCount++;
            GameObject ringPre = PoolManager.SpawnFromPool("Ring", pos); //여기를 GameObjectName으로
            scaleRing = Random.Range(0.4f, 1f);
            //public 도 실험해봐야겠다
            HookRing hookRing = ringPre.GetComponent<HookRing>();
            hookRing.RingScaleSet(scaleRing);

            ringMove = ringPre.GetComponent<RingMove>();

            //숫자마다 색깔지정도 있고
            //
            SetDistance(ringMove, num);


        }




    }

    //1이면 이렇게 값을 0으로하는것도 방법이구나
    //  이렇게 하면되는구나

    //이걸 링무브에 옴겨가지고 
    public void SetDistance(RingMove ringMove, int num) { //이것도 저쪽에서 관리?

        v = Random.Range(1f, 4f);
        h = Random.Range(1f, 4f);
        m = Random.Range(0.7f, 1f);

        if (num == 0) {
            ringMove.verticalDistance = 0;
            ringMove.horizontalDistance = 0; //그함수내에서 바꾸게 하는 흑 흑
            ringMove.moveSpeed = 0;
            ringMove.RimgMovePosSet();
            ringMove.RingMoveZero();
        }
        if (ringMove != null && num == 1) {
            //print("됨?");
            //근데 이게 독립이 아닐경우에는?
            ringMove.verticalDistance = v;
            ringMove.horizontalDistance = h; //그함수내에서 바꾸게 하는 흑 흑
            ringMove.moveSpeed = m;



            ringMove.RimgMovePosSet();
        }
    }
    private void FixedUpdate() {
        //이러니까 업데이트를 못쓰네 업데이트에서도 코루틴할수있게 해야되나?

    }



}
