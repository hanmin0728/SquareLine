using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public Vector2 MinPosition { get; private set; }
    public Vector2 MaxPosition { get; private set; }
    [SerializeField] private Transform player;
    public Transform Player { get { return player; } }

    private float timeScale = 1f;

    public ScoreManager ScoreManager { get { return scoreManager; } set { scoreManager = value; } }
    [SerializeField]
    private ScoreManager scoreManager;

    public static float TimeScale {
        get {
            if (Instance != null) {
                return Instance.timeScale;
            } else {
                return 0f;
            }

        }
        set {
            Instance.timeScale = Mathf.Clamp(value, 0, 1);
        }
    }

    private void Awake() {

    }
    void Start()
    {

        MaxPosition = new Vector2(15f, 9f);
        MinPosition = new Vector2(-15f, -9f);
    }

 
}
