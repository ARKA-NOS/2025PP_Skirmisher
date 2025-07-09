using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    Transform _player;
    HPSystem _playerHP;

    bool _canAttack = true;
    bool _contact = false;

    [SerializeField] float moveSpeed = 1;
    [SerializeField] float hitDamage = 15;
    [SerializeField] float hitDelay = 2;

    [Header("Types")]
    [SerializeField] bool Runner = false;
    [SerializeField] bool Stranik = false;
    [SerializeField] bool Ratnik = false;
    [SerializeField] bool Crab = false;
    [SerializeField] bool Hunter = false;

    [SerializeField] GameObject ammoBox;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.position, moveSpeed * Time.deltaTime);

        if (_contact && _canAttack)
        {
            _playerHP.OnDamage(hitDamage);
            StartCoroutine(AttackDelay(hitDelay));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _contact = true;
            _playerHP = collision.gameObject.GetComponent<HPSystem>();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _contact = false;
        }
    }

    private void OnDestroy()
    {
        TypeChecker();
    }

    private void TypeChecker()
    {
        int ammoBoxSpawn = Random.Range(0, 101);
        if (Runner)
        {
            if (ammoBoxSpawn < 16)
                BoxSpawn();

            DazenKillManager.Instance.KillRunner++;
            CostSystem.Instance.Cost += 150;
        }
        else if (Stranik)
        {
            if (ammoBoxSpawn < 41)
                BoxSpawn();

            DazenKillManager.Instance.KillStranik++;
            CostSystem.Instance.Cost += 200;
        }
        else if (Ratnik)
        {
            if (ammoBoxSpawn < 81)
                BoxSpawn();

            DazenKillManager.Instance.KillRatnik++;
            CostSystem.Instance.Cost += 250;
        }
        else if (Crab)
        {
            if (ammoBoxSpawn < 6)
                BoxSpawn();

            DazenKillManager.Instance.KillCrab++;
            CostSystem.Instance.Cost += 150;
        }
        else if (Hunter)
        {
            if (ammoBoxSpawn < 51)
                BoxSpawn();

            DazenKillManager.Instance.KillHunter++;
            CostSystem.Instance.Cost += 500;
        }
    }

    void BoxSpawn()
    {
        GameObject box = Instantiate(ammoBox);
        box.transform.position = gameObject.transform.position;
    }

    IEnumerator AttackDelay(float delay)
    {
        _canAttack = false;
        yield return new WaitForSeconds(delay);
        _canAttack = true;
    }
}
