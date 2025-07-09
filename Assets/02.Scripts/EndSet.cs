using TMPro;
using UnityEngine;

public class EndSet : MonoBehaviour
{
    [SerializeField] AudioSource shopMusicPlayer;
    [SerializeField] TextMeshProUGUI endKillCouter;

    private void Awake()
    {
        gameObject.SetActive(false);
        if (DazenKillManager.Instance.Daze == 19)
        {
            gameObject.SetActive(true);
            shopMusicPlayer.volume = 0;

            endKillCouter.text = 
            $"���� : {DazenKillManager.Instance.KillRunner} ����\r\n" +
            $"��Ʈ��� : {DazenKillManager.Instance.KillStranik} ����\r\n" +
            $"��Ʈ��ũ : {DazenKillManager.Instance.KillRatnik} ����\r\n" +
            $"ũ�� : {DazenKillManager.Instance.KillCrab} ����\r\n" +
            $"���� : {DazenKillManager.Instance.KillHunter} ����\r\n\n" + 
            $"����� 18�� ���� {DazenKillManager.Instance.KillAll}������\r\n����ü�� ����߽��ϴ�.";
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void QnMoveGame()
    {
        gameObject.SetActive(false);
        shopMusicPlayer.volume = 0.03f;
    }
}
