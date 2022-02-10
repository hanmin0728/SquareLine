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
            print("�÷���");
            FloatingManager.instance.TextMeshFloating("��������!", Color.green, collision.transform);

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

    //��ȯ�ϱ������� ���ǥ�ø� �����
    //�ű⿡�� SetPosition?�ϰ� �Ѵ��� ������.
    public void SetPosition()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        //Vector3 worldSize = GetSpriteSize(arrowWaringSign);
        //print(worldSize);
        // Vector3 worldToViewSize = Camera.main.WorldToViewportPoint(worldSize);

        if (Random.Range(0, 2) == 0) {
            int temp = Random.Range(0, 2);


            //��������Ʈ ũ�⸦ ���ϰ� �� ũ�⿡�� �A���� pos ��������?

            if (temp == 0) {



                pos.x = 0f;
                //pos.x = 0f + (worldToViewSize.x / 8);


            } else {
                pos.x = 1f;
                //pos.x = 1f - (worldToViewSize.x / 8);
            }



            //���ʿ��� 
            //x�������� ����������
            //���� y�� ��������
            pos.y = Random.Range(0f, 1f);
            //pos.y = Random.Range(0f + (worldToViewSize.y / 8), 1f - (worldToViewSize.y / 8));


            //���⼭ ��ȯ
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

            //���⼭ ��ȯ
        }

        //�׷� ���⼭ ��ǥ���� ���Ҽ��ְ�
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

