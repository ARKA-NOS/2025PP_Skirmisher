using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DazenKillManager : MonoBehaviour
{
    public static DazenKillManager Instance { get; set; }

    public bool GoneSet { get; set; } = false;
    public int Daze { get; set; } = 1;
    public int KillAll { get; set; } = 0;
    public int DazeEnemyCounter { get; set; } = 0;
    public int TodayKilledEnemy { get; set; } = 0;

    public int KillRunner { get; set; } = 0;
    public int KillStranik { get; set; } = 0;
    public int KillRatnik { get; set; } = 0;
    public int KillCrab { get; set; } = 0;
    public int KillHunter { get; set; } = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (!(DazeEnemyCounter == 0) && DazeEnemyCounter == TodayKilledEnemy && !GoneSet)
        {
            GoneSet = true;
            UIUpdater.Instance.ActiveGonePanel();
        }
    }
}
