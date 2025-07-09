using UnityEngine;

public class ContorlBogi : MonoBehaviour
{
    [SerializeField] GameObject contorlPanel;

    private void Awake()
    {
        contorlPanel.SetActive(false);
    }

    public void On()
    {
        contorlPanel.SetActive(true);
    }

    public void Close()
    {
        contorlPanel.SetActive(false);
    }
}
