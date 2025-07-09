using UnityEngine;
using static GunsActivate;

public class BuySave : MonoBehaviour
{
    public static BuySave Instance { get; set; }

    public bool[] buyArray { get; set; } = { buyGuns_G19, buyGuns_M9, buyGuns_DE, buyGuns_UZI, buyGuns_UMP, buyGuns_VEC, buyGuns_T56, buyGuns_M4A1, buyGuns_VHSD2, buyGuns_SA58, buyGuns_AA12, buyGuns_KORD };

    static bool buyGuns_G19 = true;
    static bool buyGuns_M9 = false;
    static bool buyGuns_DE = false;
    static bool buyGuns_UZI = false;
    static bool buyGuns_UMP = false;
    static bool buyGuns_VEC = false;
    static bool buyGuns_T56 = false;
    static bool buyGuns_M4A1 = false;
    static bool buyGuns_VHSD2 = false;
    static bool buyGuns_SA58 = false;
    static bool buyGuns_AA12 = false;
    static bool buyGuns_KORD = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
}
