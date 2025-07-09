using UnityEngine;

public class HPSystem : MonoBehaviour
{
    [SerializeField] float maxHP = 100f;
    [SerializeField] float _currentHP;
    bool _dead = false;

    private void Awake()
    {
        _currentHP = maxHP;
    }

    private void Start()
    {
        if (gameObject.CompareTag("Player"))
        {
            UIUpdater.Instance.HPTextSet(_currentHP);
        }
    }

    public void OnDamage(float damage)
    {
        if (_dead) return;

        _currentHP -= damage;
        if (gameObject.CompareTag("Player"))
        {
            UIUpdater.Instance.HPTextSet(_currentHP);
        }

        if (_currentHP <= 0)
        {
            if (gameObject.CompareTag("Enemy"))
            {
                _dead = true;
                DazenKillManager.Instance.KillAll++;
                DazenKillManager.Instance.TodayKilledEnemy++;
                UIUpdater.Instance.DazeEnemyCounterTextSet();
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("Player"))
            {
                _dead = true;
                UIUpdater.Instance.ActiveOverPanel();
            }
        }
    }
}
