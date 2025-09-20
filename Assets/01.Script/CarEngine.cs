using TMPro;
using UnityEngine;

public class CarEngine : MonoBehaviour
{
    public float CurrentSpeed { get; private set; } = 0;

    [SerializeField] private float MaxSpeed = 10f;          // 최대 속도
    [SerializeField] private float accelerationRate = 5f;   // 가속도 (m/s² 느낌)
    [SerializeField] private float decelerationRate = 8f;   // 감속도 (m/s² 느낌)

    [SerializeField] private TextMeshProUGUI SpeedTxt;

    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (playerMovement.IsMoveing)
        {
            // 가속
            CurrentSpeed += accelerationRate * Time.deltaTime;
        }
        else
        {
            // 감속
            CurrentSpeed -= decelerationRate * Time.deltaTime;
        }

        // 속도를 0 ~ MaxSpeed 범위로 고정
        CurrentSpeed = Mathf.Clamp(CurrentSpeed, 0f, MaxSpeed);

        // UI 표시
        SpeedTxt.text = CurrentSpeed.ToString("F2"); // 소수점 2자리
    }
}
