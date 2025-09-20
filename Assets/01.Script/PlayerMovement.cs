using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float MoveSpeed = 5f;
    [SerializeField] private float RotateSpeed = 5f;


    private void Update()
    {
        Vector2 input = inputManager.MoveInput;  // InputManager에서 값 가져오기

        Vector3 move = new Vector3(input.x, input.y, 0);
        transform.Translate(Vector3.up * move.y * MoveSpeed * Time.deltaTime, Space.Self); // 이동
        if (Mathf.Abs(move.y) > 0.01f) // 전/후진 중일 때만 회전
        {
            transform.Rotate(0, 0, Mathf.Sign(move.y) * -move.x * RotateSpeed * Time.deltaTime);
        }

    }
}
