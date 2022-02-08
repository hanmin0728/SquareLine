using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Invincibility(collision));
        }   
    }
    IEnumerator Invincibility(Collider2D collision)
    {
        collision.GetComponent<PolygonCollider2D>().enabled = false;
        print("公利");
        yield return new WaitForSeconds(3f);
        collision.GetComponent<PolygonCollider2D>().enabled = true;
        print("公利 秦力");

    }
}
