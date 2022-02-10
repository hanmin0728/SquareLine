using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private string layerName;
    //[SerializeField] private LayerMask layer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FloatingManager.instance.TextMeshFloating("����5��!", Color.green, gameObject.transform);

            StartCoroutine(Invincibility(collision));
        }   
    }
    IEnumerator Invincibility(Collider2D collision)
    {
        collision.gameObject.layer = LayerMask.NameToLayer(layerName);
        print(collision.gameObject.layer);
        print("����");
        collision.GetComponent<Pl>().Mujuck();
        Destroy(gameObject);
        yield return null;

        print("���� ����");
    }
}
