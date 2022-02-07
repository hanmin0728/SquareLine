using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float moveX { get; private set; }
    public bool isJump { get; private set; }

    public bool isMouse { get; private set; }

    private void Update() {

        moveX = Input.GetAxisRaw("Horizontal");
        isJump = Input.GetKeyDown(KeyCode.Space);
        isMouse = Input.GetMouseButtonDown(0);
        print(isJump);


    }
}
