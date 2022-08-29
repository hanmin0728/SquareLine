using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float moveX { get; private set; }
    public bool isJump { get; private set; }

    public bool isMouse { get; private set; }

    public bool isDown { get; private set; }

    private void Update() {

        //print(GameManager.TimeScale);
        if(GameManager.TimeScale <= 0) {
            moveX = 0;
            isJump = false;
            isMouse = false;
            isDown = false;
            //print("타임스케일 0");
            return;
        }
        moveX = Input.GetAxisRaw("Horizontal");
        isJump = Input.GetKeyDown(KeyCode.Space);
        isMouse = Input.GetMouseButtonDown(0);
        isDown = Input.GetKeyDown(KeyCode.S);



    }
}
