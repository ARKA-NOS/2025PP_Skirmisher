using UnityEngine;

public class GameSystemManager : MonoBehaviour
{

    private void Awake()
    {
        DazenKillManager.Instance.DazeEnemyCounter = (DazenKillManager.Instance.Daze * 3) + Random.Range(0, 5);
        DazenKillManager.Instance.TodayKilledEnemy = 0;
        DazenKillManager.Instance.GoneSet = false;
    }
    private void Start()
    {
        UIUpdater.Instance.AmmoUpdate();
        UIUpdater.Instance.DazeEnemyCounterTextSet();
    }
}
