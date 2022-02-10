using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.
public class Pl : MonoBehaviour
{
    [SerializeField]
    private CamManager camManager;
    [SerializeField] 
    private HeartSystem heartSystem;
    [SerializeField]
    private GameObject bloodParticle;
    int maxHp = 5;
    private int curHp=5;
    public Light light;
    private void Start()
    {
        heartSystem.Set(maxHp);
    }
    private void Update()
    {
        if (curHp == 1)
        {
            light.i
        }
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
        Instantiate(bloodParticle, transform.position, Quaternion.identity);
        camManager.SetCamShake(1.5f);
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