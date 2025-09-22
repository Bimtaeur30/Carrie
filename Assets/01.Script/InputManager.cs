using System;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }
    public Action<bool> IsDriftAction;

    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Debug.Log(moveY);
        MoveInput = new Vector2(moveX, moveY);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("시프트다운");
            IsDriftAction?.Invoke(true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Debug.Log("시프트업");
            IsDriftAction?.Invoke(false);
        }
    }
}
