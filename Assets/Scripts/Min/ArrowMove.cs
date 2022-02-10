using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour
{
    public int speed;
    public Transform target;

    private void OnEnable()
    {
        //SetPosition();

    }
    void Update()
    {
        Move();
       LimitPosition();
    }
    private void Move()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime * GameManager.TimeScale);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

  
            collision.GetComponent<Pl>().Damage(1);
            gameObject.SetActive(false);
        }
        if(collision.gameObject.layer == LayerMask.NameToLayer("Shiled")) {
            print("플로팅");
            FloatingManager.instance.TextMeshFloating("무적상태!", Color.green, collision.transform);

        }
    }
    private void LimitPosition()
    {
        if (GameManager.Instance.MaxPosition.y < Mathf.Abs(transform.position.y))
        {
            gameObject.SetActive(false);
        }
        if (GameManager.Instance.MaxPosition.x < Mathf.Abs(transform.position.x))
        {
            gameObject.SetActive(false);
        }
    }

    //소환하기이전에 경고표시를 만들고
    //거기에서 SetPosition?하고 한다음 ㅎ나다.
    public void SetPosition()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
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
                pos.x = 1f;
                //pos.x = 1f - (worldToViewSize.x / 8);
            }



            //왼쪽에서 
            //x왼쪽인지 오른쪽인지
            //그후 y는 랜덤으로
            pos.y = Random.Range(0f, 1f);
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
            pos.x = Random.Range(0f, 1f);
            //pos.x = Random.Range(0f + (worldToViewSize.x / 8), 1f - (worldToViewSize.x / 8));

            //여기서 소환
        }

        //그럼 여기서 좌표값을 구할수있고
        transform.position = Camera.main.ViewportToWorldPoint(pos);
        Vector2 dir = GameManager.Instance.Player.position - transform.position;
        dir.Normalize();
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg; 
        transform.eulerAngles = new Vector3(0, 0, angle - 90);
    }

    private void OnDisable() {
        PoolManager.ReturnToPool(gameObject);
        CancelInvoke();
    }
}

