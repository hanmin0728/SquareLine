using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPotion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
            StartCoroutine(SpeedUp(collision));
            Destroy(gameObject);
        }
    }
    IEnumerator SpeedUp(Collider2D collision)
    {
        collision.GetComponent<PlayerMove>().moveSpeed = 25f;
        yield return new WaitForSeconds(5f);
        collision.GetComponent<PlayerMove>().moveSpeed = 15f;

    }
}
