using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArrowManager : MonoBehaviour
{
    public GameObject arrowPrefab;
    public void Start()
    {
        StartCoroutine(SpawnArrow());
    }
    private IEnumerator SpawnArrow()
    {
        while (true)
        {
            GameObject arrow;
            arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }
    }
  
}
