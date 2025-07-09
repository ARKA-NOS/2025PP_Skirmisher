using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIUpdater : MonoBehaviour
{
    WeaponBase _gun;
    [SerializeField] TextMeshProUGUI ammoCounter;
    [SerializeField] TextMeshProUGUI gunName;
    [SerializeField] TextMeshProUGUI dazeEnemyCounter;
    [SerializeField] TextMeshProUGUI dayCounter;
    [SerializeField] TextMeshProUGUI HPCounter;
    [SerializeField] GameObject selectingText;
    [SerializeField] GameObject loadingText;

    [SerializeField] GameObject overPanel;
    [SerializeField] GameObject gonePanel;

    public static UIUpdater Instance { get; private set; }

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

    private void Start()
    {
        loadingText.SetActive(false);
        selectingText.SetActive(false);

        overPanel.SetActive(false);
        gonePanel.SetActive(false);
    }

    public void GunSet()
    {
        _gun = GameObject.FindGameObjectWithTag("Weapon").GetComponent<WeaponBase>();
    }
    
    public void AmmoUpdate()
    {
        ammoCounter.text = $"{_gun.LoadedAmmo} / {_gun.UnloadedAmmo}";
    }

    public void ActiveOverPanel()
    {
        if (DazenKillManager.Instance.Daze < 19)
        {
            DeadMentManager.Instance.DeadMentSet();
            Time.timeScale = 0;
        }
        else
        {
            DeadMentManager.Instance.InfinityDeadMentSet();
        }
        Time.timeScale = 0;
        overPanel.SetActive(true);

    }

    public void ActiveGonePanel()
    {
        GoneMentManager.Instance.GoneMentSet();
        Time.timeScale = 0;
        gonePanel.SetActive(true);
    }

    public void LoadingTextSet()
    {
        if (!loadingText.activeSelf)
        {
            loadingText.SetActive(true);
            return;
        }  
        
        if (loadingText.activeSelf)
        {
            loadingText.SetActive(false);
            return;
        }
            
    }

    public void SelectingTextSet()
    {
        if (!selectingText.activeSelf)
        {
            selectingText.SetActive(true);
            return;
        }

        if (selectingText.activeSelf)
        {
            selectingText.SetActive(false);
            return;
        }
    }

    public void DazeEnemyCounterTextSet()
    {
        dazeEnemyCounter.text = $"³²Àº Àû\n{DazenKillManager.Instance.TodayKilledEnemy} / {DazenKillManager.Instance.DazeEnemyCounter}";
        dayCounter.text = $"DAY {DazenKillManager.Instance.Daze}";
    }

    public void HPTextSet(float num)
    {
        HPCounter.text = $"{num}";
    }

    public void SetGunName(string name)
    {
        gunName.text = $"{name}";
    }
}
