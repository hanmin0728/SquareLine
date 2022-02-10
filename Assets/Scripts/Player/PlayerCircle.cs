using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCircle : MonoBehaviour
{

    public LayerMask layer;
    public float circleRange;
    private void Awake() {
       
    }

    private void Update() {

        
        Collider2D collider2D =Physics2D.OverlapCircle(transform.position, circleRange, layer);
        if (collider2D != null) {

            print("°¨Áö");


            GameManager.TimeScale = 0.4f;
        } else if(collider2D == null) {
            GameManager.TimeScale = 1;
        }
           

    }
}
