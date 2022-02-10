using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private Transform player;
    public Transform Player { get { return player; } }

    private float timeScale = 1;

    public static float TimeScale { get { return Instance.timeScale; } set { Instance.timeScale = value; } }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
