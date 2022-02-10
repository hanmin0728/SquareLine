using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
   public HeartSystem heartSystem;
    private void Start()
    {
        heartSystem = FindObjectOfType<HeartSystem>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Pl>().Heal(1);
            Destroy(gameObject);
        }
    }
}
