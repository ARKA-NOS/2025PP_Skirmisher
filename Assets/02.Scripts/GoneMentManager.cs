using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoneMentManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMainDaze;
    [SerializeField] TextMeshProUGUI textKill;
    [SerializeField] TextMeshProUGUI goneMent;

    [SerializeField] string[] mentArray;

    public static GoneMentManager Instance { get; private set; }

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

    public void GoneMentSet()
    {
        textMainDaze.text = $"DAY {DazenKillManager.Instance.Daze} : 살아남았습니다";
        textKill.text = $"당신은 오늘 {DazenKillManager.Instance.TodayKilledEnemy}마리의 감염체를 사살했습니다.";
        goneMent.text = mentArray[Random.Range(0, mentArray.Length)];
    }
}
