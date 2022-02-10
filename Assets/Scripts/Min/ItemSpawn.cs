using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] items = new GameObject[3];
    private void Start()
    {
        StartCoroutine(SpawnItem());
    }
    private IEnumerator SpawnItem()
    {
        while (true)
        {
            float randomX = Random.Range(GameManager.Instance.MinPosition.x, GameManager.Instance.MaxPosition.x);
            float randomY = Random.Range(GameManager.Instance.MinPosition.y, GameManager.Instance.MaxPosition.y);
            yield return new WaitForSeconds(7f);
            int rand = Random.Range(0, 3);
            GameObject obj = Instantiate(items[rand]);
            obj.transform.position = new Vector2(randomX, randomY);
            yield return new WaitForSeconds(3.5f);
        }
    }
   
}
