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
        Vector2 input = inputManager.MoveInput;  // InputManager에서 값 가져오기
                                                 // 이동 방향 갱신
        if (input != Vector2.zero)
        {
            lastInput = new Vector3(input.x, input.y, 0);

            if (Mathf.Abs(lastInput.y) > 0.01f)
            {
                transform.Rotate(0, 0, Mathf.Sign(lastInput.y) * -lastInput.x * RotateSpeed * Time.deltaTime);
            }
        }

        // 이동
        transform.Translate(Vector3.up * Mathf.Sign(lastInput.y) * carEngine.CurrentSpeed * Time.deltaTime, Space.Self);

        // IsMoveing: 입력이 있을 때만 켬, 감속 중에는 꺼짐
        IsMoveing = Mathf.Abs(input.y) > 0.01f;

    }
}
