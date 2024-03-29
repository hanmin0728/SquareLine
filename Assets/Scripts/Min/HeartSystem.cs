using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class HeartSystem : MonoBehaviour
{
    [SerializeField] 
    private GameObject heart;

    [SerializeField]
    private Transform trans;
     
    [SerializeField] 
    private GameObject[] objects;
    public void Set(int _maxHp)
    {
        objects = new GameObject[_maxHp];
        for (int i = 0; i < _maxHp; i++)
        {
            GameObject obj = Instantiate(heart, trans);
            obj.SetActive(true);
            objects[i] = obj;
        }
    }
    public void Heart(int _hp)
    {
        for (int i = objects.Length - 1; i >= _hp; i--)
        {
            objects[i].GetComponent<Image>().color = Color.gray;
        }
        for (int i = 0; i < _hp; i++)
        {
            objects[i].GetComponent<Image>().color = Color.red;
        }
    }
}