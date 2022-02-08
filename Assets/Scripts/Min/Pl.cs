using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pl : MonoBehaviour
{
    [SerializeField] 
    private HeartSystem heartSystem;
    int maxHp = 5;
    private int curHp=5;
    private void Start()
    {
        heartSystem.Set(maxHp);
    }
    public void Heal(int amount)
    {
        curHp += amount;
        if (curHp >= maxHp)
        {
            curHp = maxHp;
        }
        heartSystem.Heart(curHp);
    }
    public void Damage(int damage)
    {
        curHp -= damage;
        if (curHp > maxHp)
        {
            curHp = maxHp;
        }
        else if (curHp <= 0)
        {
            Dead();
        }
        heartSystem.Heart(curHp);
    }
    public void Dead()
    {
        print("Á×À½");
    }
}