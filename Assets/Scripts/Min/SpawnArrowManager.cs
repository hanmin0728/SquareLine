using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArrowManager : MonoBehaviour { 

    public static SpawnArrowManager instance;

 

    public GameObject arrowWaringSign;


    private void Awake() {
        instance = this;
    }
    public void Start()
    {
        StartCoroutine(SpawnArrow());

    }
    private IEnumerator SpawnArrow()
    {
        while (true)
        {
            Vector3 pos = SetPosition(arrowWaringSign);
            GameObject arrow; //전역이 아닌 여기인 이유는 독립성을 위함인가
            arrow = PoolManager.SpawnFromPool("WarningSign", pos, Quaternion.identity);
            arrow.transform.position = Camera.main.ViewportToWorldPoint(pos);
            //위치에 소환해주고 
            yield return new WaitForSeconds(2f);
        }
    }

    public Vector3 GetSpriteSize(GameObject _target) {
        Vector3 worldSize = Vector3.zero;
        if(_target.GetComponent<SpriteRenderer>()) {
            Vector2 spriteSize = _target.GetComponent<SpriteRenderer>().sprite.rect.size;
            Vector2 localSpriteSize = spriteSize / _target.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
            worldSize = localSpriteSize;
            worldSize.x *= _target.transform.lossyScale.x;
            worldSize.y *= _target.transform.lossyScale.y;
        }
        else {
            Debug.Log("SpriteRenderer Null");
        }

    
        return worldSize;
    }

    public Vector3 SetPosition(GameObject _target) {

        Vector3 pos = Camera.main.WorldToViewportPoint(_target.transform.position);
        //Vector3 worldSize = GetSpriteSize(arrowWaringSign);
        //print(worldSize);
       // Vector3 worldToViewSize = Camera.main.WorldToViewportPoint(worldSize);
  
        if (Random.Range(0, 2) == 0) {
            int temp = Random.Range(0, 2);


            //스프라이트 크기를 구하고 그 크기에서 뺸값을 pos 에넣으면?
           
            if (temp == 0) {


                
                pos.x = 0f;
                //pos.x = 0f + (worldToViewSize.x / 8);


            } else {
                 pos.x =1f;
                //pos.x = 1f - (worldToViewSize.x / 8);
            }



            //왼쪽에서 
            //x왼쪽인지 오른쪽인지
            //그후 y는 랜덤으로
            pos.y = Random.Range(0f , 1f);
            //pos.y = Random.Range(0f + (worldToViewSize.y / 8), 1f - (worldToViewSize.y / 8));


            //여기서 소환
        } else {
            int temp = Random.Range(0, 2);
            if (temp == 0) {
                 pos.y = 0f;
                //pos.y = 0f + (worldToViewSize.y / 8);
            } else {
                pos.y = 1f;
                //pos.y = 1f - (worldToViewSize.y / 8);
            }

            // print(pos.y + worldToViewSize.y);
            pos.x = Random.Range(0f , 1f );
            //pos.x = Random.Range(0f + (worldToViewSize.x / 8), 1f - (worldToViewSize.x / 8));

            //여기서 소환
        }

        return pos;


    }

}
