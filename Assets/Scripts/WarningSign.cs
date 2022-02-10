using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningSign : MonoBehaviour {

    SpriteRenderer sprite;

    public Color[] colorSet = new Color[2];
    private void OnEnable() {
        sprite = GetComponent<SpriteRenderer>();
        StartCoroutine(ColorToggle());
    }
    public IEnumerator ColorToggle() {


        for (int i = 0; i < 4; i++) {

            sprite.color = colorSet[0];
            yield return new WaitForSeconds(0.15f);
            sprite.color = colorSet[1];
            yield return new WaitForSeconds(0.15f);
            
        }


        GameObject arrow = PoolManager.SpawnFromPool("arrow", transform.position);

        ArrowMove arrowMove = arrow.GetComponent<ArrowMove>();

        arrowMove.SetPosition();

        gameObject.SetActive(false);




    }


    private void OnDisable() {

        //펄스가 될떄 생성하거나
        PoolManager.ReturnToPool(gameObject);
        CancelInvoke();
       

    }



}
