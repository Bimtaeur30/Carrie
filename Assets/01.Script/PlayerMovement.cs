using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float RotateSpeed = 5f;
    public bool IsMoveing;

    private Vector3 lastInput = Vector3.up;

    CarEngine carEngine;

    private void Awake()
    {
        carEngine = GetComponent<CarEngine>();
    }


    private void Update()
    {
        Vector2 input = inputManager.MoveInput;  // InputManager���� �� ��������
                                                 // �̵� ���� ����
        if (input != Vector2.zero)
        {
            lastInput = new Vector3(input.x, input.y, 0);

            if (Mathf.Abs(lastInput.y) > 0.01f)
            {
                transform.Rotate(0, 0, Mathf.Sign(lastInput.y) * -lastInput.x * RotateSpeed * Time.deltaTime);
            }
        }

        // �̵�
        transform.Translate(Vector3.up * Mathf.Sign(lastInput.y) * carEngine.CurrentSpeed * Time.deltaTime, Space.Self);

        // IsMoveing: �Է��� ���� ���� ��, ���� �߿��� ����
        IsMoveing = Mathf.Abs(input.y) > 0.01f;

    }
}
