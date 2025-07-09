using UnityEngine;

public class BulletBase : MonoBehaviour
{
    WeaponBase _gun;
    HPSystem _enemyHP;

    [SerializeField] string ammoType;

    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] float bulletLifeTime = 5f;

    [SerializeField] float bulletDamage = 30;

    private void Start()
    {
        _gun = GameObject.FindGameObjectWithTag("Weapon").GetComponent<WeaponBase>();
        bulletDamage *= _gun.Multiplier;

        Destroy(gameObject, bulletLifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Bullet")) return;

        if (collision.CompareTag("Enemy"))
        {
            _enemyHP = collision.gameObject.GetComponent<HPSystem>();
            _enemyHP.OnDamage(bulletDamage);
        }
        Destroy(gameObject);
    }
}
