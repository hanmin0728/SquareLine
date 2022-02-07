using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    RingSpawner ringSpawner;
    public GameObject prefabRing;
    SpriteRenderer circleSprtie;

    private float xRange;
    private float yRange;
    private void Start() {
        ringSpawner = GameObject.Find("Image").GetComponent<RingSpawner>();
        circleSprtie = prefabRing.GetComponent<SpriteRenderer>();
        xRange = ringSpawner.imageSizeX;
        yRange = ringSpawner.ImageSizeY;
        StartCoroutine(Spawn());

        Debug.Log($"{xRange}, {yRange}");
        
    }

 

    private IEnumerator Spawn() {
        Camera mainCam = Camera.main;
        while(true) {

            

            float x = Random.Range(0 + circleSprtie.bounds.size.x, xRange - circleSprtie.bounds.size.x); //1665.87 0이라서 이미지의 posX , PosY
            
            float y = Random.Range(0 + circleSprtie.bounds.size.x, yRange - circleSprtie.bounds.size.x); //870.0401
            //Debug.Log($"{x} {y}");

         


            Vector3 range = new Vector3(x, y, mainCam.nearClipPlane);//오버헤드
            range = ringSpawner.GetScreenPosition(range); //pos.x + 1670 
            //최소에선 더하고 
            // 최대에선 뺴야되는데 
            // x 반이상이면 
            // 127 + 104 


            Debug.Log(range);
            Vector3 pos = mainCam.ScreenToWorldPoint(range);
            pos.z = 0;
            //findObject Cmaera.main
            Instantiate(prefabRing, pos, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
        
    }
}
