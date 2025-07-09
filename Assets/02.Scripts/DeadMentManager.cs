using TMPro;
using UnityEngine;

public class DeadMentManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textDaze;
    [SerializeField] TextMeshProUGUI textKill;
    [SerializeField] TextMeshProUGUI textKillDetails;
    [SerializeField] TextMeshProUGUI deadMent;

    [SerializeField] string[] mentArray;

    public static DeadMentManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DeadMentSet()
    {
        textDaze.text = $"����� {DazenKillManager.Instance.Daze}���� ���������� Ż�������� �� �߽��ϴ�.";
        textKill.text = $"����� �� {DazenKillManager.Instance.KillAll}������ ����ü�� ����߽��ϴ�.";
        textKillDetails.text =
            $"���� : {DazenKillManager.Instance.KillRunner} ����\r\n" +
            $"��Ʈ��� : {DazenKillManager.Instance.KillStranik} ����\r\n" +
            $"��Ʈ��ũ : {DazenKillManager.Instance.KillRatnik} ����\r\n" +
            $"ũ�� : {DazenKillManager.Instance.KillCrab} ����\r\n" +
            $"���� : {DazenKillManager.Instance.KillHunter} ����\r\n";

        deadMent.text = mentArray[Random.Range(0, mentArray.Length)];
    }

    public void InfinityDeadMentSet()
    {
        textDaze.text = $"���� ��� : ����� {DazenKillManager.Instance.Daze - 18}���� �߰��� �����߽��ϴ�.";
        textKill.text = $"����� �� {DazenKillManager.Instance.KillAll}������ ����ü�� ����߽��ϴ�.";
        textKillDetails.text =
            $"���� : {DazenKillManager.Instance.KillRunner} ����\r\n" +
            $"��Ʈ��� : {DazenKillManager.Instance.KillStranik} ����\r\n" +
            $"��Ʈ��ũ : {DazenKillManager.Instance.KillRatnik} ����\r\n" +
            $"ũ�� : {DazenKillManager.Instance.KillCrab} ����\r\n" +
            $"���� : {DazenKillManager.Instance.KillHunter} ����\r\n";

        deadMent.text = mentArray[Random.Range(0, mentArray.Length)];
    }
}
