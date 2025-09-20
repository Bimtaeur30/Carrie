using System.Data.SqlTypes;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }
    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Debug.Log(moveY);
        MoveInput = new Vector2(moveX, moveY);
    }
}
