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
            $"러너 : {DazenKillManager.Instance.KillRunner} 마리\r\n" +
            $"스트라닉 : {DazenKillManager.Instance.KillStranik} 마리\r\n" +
            $"라트니크 : {DazenKillManager.Instance.KillRatnik} 마리\r\n" +
            $"크랩 : {DazenKillManager.Instance.KillCrab} 마리\r\n" +
            $"헌터 : {DazenKillManager.Instance.KillHunter} 마리\r\n\n" + 
            $"당신은 18일 동안 {DazenKillManager.Instance.KillAll}마리의\r\n감염체를 사살했습니다.";
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
