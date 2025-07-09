using UnityEngine;

public class GunInfoManager : MonoBehaviour
{
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject[] gunInfoArray;

    private void Awake()
    {
        for (int i = 0; i < gunInfoArray.Length; i++)
        {
            gunInfoArray[i].SetActive(false);
        }
    }
    public void InfoE(int num)
    {
        startPanel.SetActive(false);
        gunInfoArray[num].SetActive(true);
    }

    public void InfoD(int num)
    {
        startPanel.SetActive(true);
        gunInfoArray[num].SetActive(false);
    }
}
