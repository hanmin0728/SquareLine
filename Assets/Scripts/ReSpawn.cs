using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawn : MonoBehaviour
{

    public RectTransform Re;
    private void OnTriggerEnter2D(Collider2D collision) {

        Re.anchoredPosition = Vector2.zero;



    }
}
