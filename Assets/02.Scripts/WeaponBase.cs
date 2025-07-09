using System.Collections;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class WeaponBase : MonoBehaviour
{
    CinemachineImpulseSource impulseSource;

    [SerializeField] string gun;
    [SerializeField] string ammoType;

    [SerializeField] Transform firePos;
    [SerializeField] GameObject bullet;
    [SerializeField] AudioClip fireSound;
    [SerializeField] AudioClip reloadSound;
    [SerializeField] bool automaticMod = false;
    [SerializeField] bool autoOnly = false;
    [SerializeField] bool selector = true;
    [SerializeField] int bulletOneShot = 1;
    [SerializeField] float fireDelay = 0.5f;
    [SerializeField] float reloadDelay = 3.5f;
    [SerializeField] float AccuracyAngle = 1.2f;
    [SerializeField] float ShakeAmount = 1.2f;

    [field: SerializeField] public int maxAmmo { get; private set; } = 30;
    
    float angle;
    bool isLoading = false;

    SpriteRenderer _sr;
    AudioSource _as;
    Animator _animator;

    [field:SerializeField] public float Multiplier { get; private set; } = 1.0f;
    public bool CanFire { get; set; } = true;
    public int UnloadedAmmo { get; set; } = 0;
    public int LoadedAmmo { get; private set; } = 0;
    public int MagazineNumber { get; set; } = 5;

    private void Awake()
    {
        UIUpdater.Instance.GunSet();

        impulseSource = GetComponentInChildren<CinemachineImpulseSource>();
        _sr = GetComponent<SpriteRenderer>();
        _as = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();

        LoadedAmmo = maxAmmo;
        UnloadedAmmo = maxAmmo * MagazineNumber;

        if (selector)
            automaticMod = true;
    }

    private void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;

        Selector();
        Reload();

        if (90.1f < angle || angle < -90f)
        {
            _sr.flipY = true;
        }
        else
        {
            _sr.flipY = false;
        }
    }

    IEnumerator Delay(float delay)
    {
        CanFire = false;
        yield return new WaitForSeconds(delay);
        CanFire = true;
    }

    IEnumerator SelectingDelay(float delay)
    {
        CanFire = false;
        UIUpdater.Instance.SelectingTextSet();
        yield return new WaitForSeconds(delay);
        UIUpdater.Instance.SelectingTextSet();
        CanFire = true;
    }

    IEnumerator LoadingDelay(float delay)
    {
        CanFire = false;
        isLoading = true;
        UIUpdater.Instance.LoadingTextSet();
        yield return new WaitForSeconds(delay);
        UIUpdater.Instance.LoadingTextSet();
        UIUpdater.Instance.AmmoUpdate();
        isLoading = false;
        CanFire = true;
    }

    private void GenerateImpulse(float intensity)
    {
        if (impulseSource != null)
        {
            impulseSource.GenerateImpulse(intensity);
        }
        else
        {
            Debug.LogWarning("ImpulseSource is not assigned to weapon: " + name);
        }
    }

    private void Selector()
    {
        if (LoadedAmmo == 0)
        {
            return;
        }
        
        if (automaticMod)
        {
            if (Mouse.current.leftButton.isPressed && !isLoading)
            {
                if (CanFire && !(LoadedAmmo == 0))
                {
                    Fire();
                }
            }
        }

        if (!automaticMod)
        {
            if (Mouse.current.leftButton.wasPressedThisFrame && !isLoading)
            {
                if (CanFire && !(LoadedAmmo == 0))
                {
                    Fire();
                }
            }
        }

        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            if (selector && automaticMod && !autoOnly)
            {
                automaticMod = false;
                StartCoroutine(SelectingDelay(0.5f));
            }
            else if (selector && !automaticMod && !autoOnly)
            {
                automaticMod = true;
                StartCoroutine(SelectingDelay(0.5f));
            }
        }
    }

    private void Fire()
    {
        LoadedAmmo--;
        for (int i = 0; i < bulletOneShot; i++)
        {
            Instantiate(bullet, firePos.position, Quaternion.AngleAxis((angle - 90) + Random.Range(-AccuracyAngle, AccuracyAngle), Vector3.forward));
        }
        _as.PlayOneShot(fireSound);
        _animator.SetTrigger("Shoot");
        UIUpdater.Instance.AmmoUpdate();
        GenerateImpulse(ShakeAmount);
        StartCoroutine(Delay(fireDelay));
    }

    private void Reload()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame && !isLoading)
        {
            if (LoadedAmmo == maxAmmo || UnloadedAmmo == 0)
            {
                return;
            }

            if (UnloadedAmmo >= maxAmmo)
            {
                StartCoroutine(LoadingDelay(reloadDelay));
                _as.PlayOneShot(reloadSound);

                int reloadAmmo = maxAmmo - LoadedAmmo;
                LoadedAmmo = maxAmmo;
                UnloadedAmmo -= reloadAmmo;
                
            }
            else if (UnloadedAmmo < maxAmmo)
            {
                StartCoroutine(LoadingDelay(reloadDelay));
                _as.PlayOneShot(reloadSound);

                LoadedAmmo += UnloadedAmmo;
                UnloadedAmmo = 0;
                if (LoadedAmmo > maxAmmo)
                {
                    int temp = LoadedAmmo - maxAmmo;
                    LoadedAmmo = maxAmmo;
                    UnloadedAmmo = temp;
                }
            }
        }
    }
}
