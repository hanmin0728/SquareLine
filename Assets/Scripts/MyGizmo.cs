using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGizmo : MonoBehaviour
{
    public Color color;
    public float radius;

    void OnDrawGizmos() {
        Gizmos.color = color;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
