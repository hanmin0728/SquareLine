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

    public IEnumerator Spawn() {
        Camera mainCam = Camera.main;
        while (true) {


            yield return new WaitUntil(() => PoolManager.inst.isStart);
            if (currentRingCount >= maxRingCount) {
                yield return null;
                continue;
            }


            //
            float x = Random.Range(0 + circleSprtie.bounds.size.x, xRange - circleSprtie.bounds.size.x); //1665.87 0이라서 이미지의 posX , PosY

            float y = Random.Range(0 + circleSprtie.bounds.size.x, yRange - circleSprtie.bounds.size.x); //870.0401
            Vector3 range = new Vector3(x, y, mainCam.nearClipPlane);//오버헤드
            range = ringSpawner.GetScreenPosition(range); //new Vector2(pos.x + 1670 , pos.y + 870)
                                                          //최소에선 더하고 
                                                          // 최대에선 뺴야되는데 
                                                          // x 반이상이면 
                                                          // 127 + 104 


            // Debug.Log(range);
            Vector3 pos = mainCam.ScreenToWorldPoint(range);
            pos.z = 0;

            //여기에서 이미 나타날 위치를 정했으니까 여기에서 범위표시하는 이미지? 이펙트하면 도리

            //Instantiate(RingSign, pos, Quaternion.identity);

            //계속발생하려면?
            GameObject prefab = PoolManager.SpawnFromPool("RingSign", pos);
            previewSigh Sign = prefab.GetComponent<previewSigh>();
            // StopCoroutine(Sign.ColorToggle());
            int num = Random.Range(0, 3);

            switch (num) {
                case 0:
                case 1:
                num = 0;
                break;
                case 2:
                num = 1;
                break;
            }

            yield return StartCoroutine(Sign.ColorToggle(num));

            //훅링스크립트나 자료형을 가져와서 하는방법이나 여기에서 태어나는 것을 미리 정해준다거나

            //독립성을 가지는 방법은 태어난 곳에서 하거나 
            RingMove ringMove = null;

            //bool Com = false;
            //생성한곳에서 독립을 할수있음. 퍼블릭은 실험

            //실행시점스바루
            //완료되기도 전에 트루가 되기때문인가>?
            yield return new WaitUntil(() => prefab.GetComponent<previewSigh>().isColorComplet);
            //StopCoroutine(Sign.ColorToggle(num));
            currentRingCount++;
            GameObject ringPre = PoolManager.SpawnFromPool("Ring", pos);
            scaleRing = Random.Range(0.4f, 1f);
            //public 도 실험해봐야겠다
            HookRing hookRing = ringPre.GetComponent<HookRing>();
            hookRing.RingScaleSet(scaleRing);

            ringMove = ringPre.GetComponent<RingMove>();



            v = Random.Range(1f, 4f);
            h = Random.Range(1f, 4f);
            m = Random.Range(0.7f, 1f);


            if (ringMove != null && num == 1) {

                //근데 이게 독립이 아닐경우에는?
                ringMove.verticalDistance = v;
                ringMove.horizontalDistance = h;
                ringMove.moveSpeed = m;
            }

            yield return new WaitForSeconds(0.3f);

            //yield return new WaitForSeconds(1f);
            //아니면 previewSigh에서 관리하거나

            //findObject Cmaera.main
            //생성할떄 미리 알려주는 표시?

        }

    }



    private void FixedUpdate() {
        //이러니까 업데이트를 못쓰네 업데이트에서도 코루틴할수있게 해야되나?

    }



}
