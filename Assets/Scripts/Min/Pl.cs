using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pl : MonoBehaviour
{
    [SerializeField]
    private CamManager camManager;
    [SerializeField]
    private HeartSystem heartSystem;
    [SerializeField]
    private GameObject bloodParticle;
    [SerializeField] 
    private string PlayerlayerName;

    int maxHp = 5;
    private int curHp = 5;
    private void Start()
    {
        heartSystem.Set(maxHp);
    }
    private void Update()
    {
       
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
        camManager.SetCamShake(1.5f,3f);
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
    public void Mujuck()
    {
        StartCoroutine(Invin());
    }
    public IEnumerator Invin()
    {
        yield return new WaitForSeconds(5f);
        gameObject.layer = LayerMask.NameToLayer(PlayerlayerName);

    }
}