using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        FloatingManager.instance.TextMeshFloating($"hp {amount}회복", Color.red, gameObject.transform);
        curHp += amount;
        if (curHp >= maxHp)
        {
            curHp = maxHp;
        }
        heartSystem.Heart(curHp);
    }


    public void Damage(int damage)
    {
        if(gameObject.layer == LayerMask.NameToLayer("Shiled")) {
        
            return;
        }
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
    public RectTransform RetryButton;

    public void Dead()
    {

        print("죽음");
        GameManager.TimeScale = 0;
        print("게임매니저 타임스케일값 = "  + GameManager.TimeScale);
        RetryButton.anchoredPosition = Vector2.zero;


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