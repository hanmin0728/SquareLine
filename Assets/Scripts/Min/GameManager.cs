using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private Transform player;
    public Transform Player { get { return player; } }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
