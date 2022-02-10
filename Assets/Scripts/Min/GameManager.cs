using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public Vector2 MinPosition { get; private set; }
    public Vector2 MaxPosition { get; private set; }
    [SerializeField] private Transform player;
    public Transform Player { get { return player; } }

    private float timeScale = 1;

    public static float TimeScale { get { return Instance.timeScale; } set { Instance.timeScale = value; } }
    void Start()
    {
        MaxPosition = new Vector2(15f, 9f);
        MinPosition = new Vector2(-15f, -9f);
    }

 
}
