using UnityEngine;

public class CostSystem : MonoBehaviour
{
    public static CostSystem Instance { get; set; }

    public int Cost { get; set; } = 500;

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
