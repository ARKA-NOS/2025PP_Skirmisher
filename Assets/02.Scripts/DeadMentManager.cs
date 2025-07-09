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
        textDaze.text = $"당신은 {DazenKillManager.Instance.Daze}일을 생존했지만 탈출하지는 못 했습니다.";
        textKill.text = $"당신은 총 {DazenKillManager.Instance.KillAll}마리의 감염체를 사살했습니다.";
        textKillDetails.text =
            $"러너 : {DazenKillManager.Instance.KillRunner} 마리\r\n" +
            $"스트라닉 : {DazenKillManager.Instance.KillStranik} 마리\r\n" +
            $"라트니크 : {DazenKillManager.Instance.KillRatnik} 마리\r\n" +
            $"크랩 : {DazenKillManager.Instance.KillCrab} 마리\r\n" +
            $"헌터 : {DazenKillManager.Instance.KillHunter} 마리\r\n";

        deadMent.text = mentArray[Random.Range(0, mentArray.Length)];
    }

    public void InfinityDeadMentSet()
    {
        textDaze.text = $"무한 모드 : 당신은 {DazenKillManager.Instance.Daze - 18}일을 추가로 생존했습니다.";
        textKill.text = $"당신은 총 {DazenKillManager.Instance.KillAll}마리의 감염체를 사살했습니다.";
        textKillDetails.text =
            $"러너 : {DazenKillManager.Instance.KillRunner} 마리\r\n" +
            $"스트라닉 : {DazenKillManager.Instance.KillStranik} 마리\r\n" +
            $"라트니크 : {DazenKillManager.Instance.KillRatnik} 마리\r\n" +
            $"크랩 : {DazenKillManager.Instance.KillCrab} 마리\r\n" +
            $"헌터 : {DazenKillManager.Instance.KillHunter} 마리\r\n";

        deadMent.text = mentArray[Random.Range(0, mentArray.Length)];
    }
}
