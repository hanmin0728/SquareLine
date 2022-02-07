using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour
{
    public int speed;
    public Transform target;

    private void OnEnable()
    {
        SetPosition();
    }
    void Update()
    {
        Move();
        //LimitPosition();
    }
    private void Move()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    //private void LimitPosition()
    //{
    //    if (GameManager.Instance.MaxPosition.y < Mathf.Abs(transform.position.y))
    //    {
    //        allPooler.DeSpawn();
    //    }
    //    if (GameManager.Instance.MaxPosition.x < Mathf.Abs(transform.position.x))
    //    {
    //        allPooler.DeSpawn();
    //    }
    //}
    void SetPosition()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (Random.Range(0, 2) == 0)
        {
            int temp = Random.Range(0, 2);
            if (temp == 0)
            {
                pos.x = 0;
            }
            else
            {
                pos.x = 1;
            }
            pos.y = Random.Range(0f, 1f);
        }
        else
        {
            int temp = Random.Range(0, 2);
            if (temp == 0)
            {
                pos.y = 0;
            }
            else
            {
                pos.y = 1;
            }
            pos.x = Random.Range(0f, 1f);
        }
        transform.position = Camera.main.ViewportToWorldPoint(pos);
        Vector2 dir = GameManager.Instance.Player.position - transform.position;
        dir.Normalize();
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg; 
        transform.eulerAngles = new Vector3(0, 0, angle - 90);
    }
}

