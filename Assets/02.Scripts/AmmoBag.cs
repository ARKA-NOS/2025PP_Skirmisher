using System.Net;
using UnityEngine;

public class AmmoBag : MonoBehaviour
{
    WeaponBase _wb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _wb = GameObject.FindGameObjectWithTag("Weapon").GetComponent<WeaponBase>();
            _wb.UnloadedAmmo += _wb.maxAmmo * 2;
            UIUpdater.Instance.AmmoUpdate();
            Destroy(gameObject);
        }
    }
}
