using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GroundPlat : MonoBehaviour
{
    // Start is called before the first frame update

    private void Start() {
        transform.DOMoveY(1f, 2f);
    }
    private void Update() {
   
    }

    private void OnCollisionExit2D(Collision2D collision) {
        gameObject.SetActive(false);
    }
}
