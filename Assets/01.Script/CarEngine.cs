using TMPro;
using UnityEngine;

public class CarEngine : MonoBehaviour
{
    public float CurrentSpeed { get; private set; } = 0;

    [SerializeField] private float MaxSpeed = 10f;          // �ִ� �ӵ�
    [SerializeField] private float accelerationRate = 5f;   // ���ӵ� (m/s�� ����)
    [SerializeField] private float decelerationRate = 8f;   // ���ӵ� (m/s�� ����)

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
            // ����
            CurrentSpeed += accelerationRate * Time.deltaTime;
        }
        else
        {
            // ����
            CurrentSpeed -= decelerationRate * Time.deltaTime;
        }

        // �ӵ��� 0 ~ MaxSpeed ������ ����
        CurrentSpeed = Mathf.Clamp(CurrentSpeed, 0f, MaxSpeed);

        // UI ǥ��
        SpeedTxt.text = CurrentSpeed.ToString("F2"); // �Ҽ��� 2�ڸ�
    }
}
