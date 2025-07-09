using UnityEngine;

public class GunsActivate : MonoBehaviour
{
    public static GunsActivate Instance { get; set; }

    public enum WeaponType
    {
        Glock19,
        M9A1,
        DE,
        UZI,
        UMP40,
        Vector,
        Type56,
        M4A1,
        VHSD2,
        SA58,
        AA12,
        Kord
    }

    public WeaponType? _currentActiveWeapon = WeaponType.Glock19;

    public bool Glock19Activate => _currentActiveWeapon == WeaponType.Glock19;
    public bool M9A1Activate => _currentActiveWeapon == WeaponType.M9A1;
    public bool DEActivate => _currentActiveWeapon == WeaponType.DE;
    public bool UZIActivate => _currentActiveWeapon == WeaponType.UZI;
    public bool UMP40Activate => _currentActiveWeapon == WeaponType.UMP40;
    public bool VectorActivate => _currentActiveWeapon == WeaponType.Vector;
    public bool Type56Activate => _currentActiveWeapon == WeaponType.Type56;
    public bool M4A1Activate => _currentActiveWeapon == WeaponType.M4A1;
    public bool VHSD2Activate => _currentActiveWeapon == WeaponType.VHSD2;
    public bool SA58Activate => _currentActiveWeapon == WeaponType.SA58;
    public bool AA12Activate => _currentActiveWeapon == WeaponType.AA12;
    public bool KordActivate => _currentActiveWeapon == WeaponType.Kord;

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
}
