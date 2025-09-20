using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float MoveSpeed = 5f;
    [SerializeField] private float RotateSpeed = 5f;


    private void Update()
    {
        Vector2 input = inputManager.MoveInput;  // InputManager���� �� ��������

        Vector3 move = new Vector3(input.x, input.y, 0);
        transform.Translate(Vector3.up * move.y * MoveSpeed * Time.deltaTime, Space.Self); // �̵�
        if (Mathf.Abs(move.y) > 0.01f) // ��/���� ���� ���� ȸ��
        {
            transform.Rotate(0, 0, Mathf.Sign(move.y) * -move.x * RotateSpeed * Time.deltaTime);
        }

    }
}
