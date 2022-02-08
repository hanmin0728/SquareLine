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
    public int maxRingCount; //클래스화?
    public static int currentRingCount ;
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
        
    
        //소환할때마다 카운트가 플러스되 맥스가 되면 더이상 생성하지마
        // 훅이 명중하면 사라져 몇초후에 
        // 생성하면 또 카운트플러스가되

    }

    private IEnumerator Spawn() {
        Camera mainCam = Camera.main;
        while(true) {

            if(currentRingCount >= maxRingCount) {
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


           // Debug.Log(range);
            Vector3 pos = mainCam.ScreenToWorldPoint(range);
            pos.z = 0;

            //여기에서 이미 나타날 위치를 정했으니까 여기에서 범위표시하는 이미지? 이펙트하면 도리

            Instantiate(RingSign, pos, Quaternion.identity);

            //여기에서 함수로 다끝나고 난후 인스텐티어트를 하면되나?
            

            //findObject Cmaera.main
            Instantiate(prefabRing, pos, Quaternion.identity);
            //생성할떄 미리 알려주는 표시?
            currentRingCount++;
            yield return new WaitForSeconds(1f);
        }
        
    }


    
}
