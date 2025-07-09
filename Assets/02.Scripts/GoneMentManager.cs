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
        textMainDaze.text = $"DAY {DazenKillManager.Instance.Daze} : ��Ƴ��ҽ��ϴ�";
        textKill.text = $"����� ���� {DazenKillManager.Instance.TodayKilledEnemy}������ ����ü�� ����߽��ϴ�.";
        goneMent.text = mentArray[Random.Range(0, mentArray.Length)];
    }
}
