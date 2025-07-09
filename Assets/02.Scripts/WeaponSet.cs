using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static GunsActivate;
using static UnityEngine.Rendering.DebugUI;

public class WeaponSet : MonoBehaviour
{
    int num;
    [SerializeField] Image[] btImage;
    [SerializeField] TextMeshProUGUI tgui;

    AudioSource _as;
    [SerializeField] AudioClip fail;
    [SerializeField] AudioClip buy;

    private void Start()
    {
        BuyCheck();
        _as = gameObject.GetComponent<AudioSource>();
    }

    public void GunsSet(int nums)
    {
        num = nums;
        if (BuySave.Instance.buyArray[num])
        {
            WeaponType temp = (WeaponType)num;
            GunsActivate.Instance._currentActiveWeapon = temp;
        }
        else
        {
            return;
        }
    }

    public void GunsBuy(int values)
    {
        if (!BuySave.Instance.buyArray[num])
        {
            if(values <= CostSystem.Instance.Cost)
            {
                CostSystem.Instance.Cost -= values;
                BuySave.Instance.buyArray[num] = true;
                btImage[num].color = Color.white;
                tgui.text = "구매 성공";
                Invoke("SetDefault", 1);
                _as.PlayOneShot(buy);
            }
            else if (values > CostSystem.Instance.Cost)
            {
                tgui.text = "구매 실패";
                Invoke("SetDefault", 1);
                _as.PlayOneShot(fail);
            }
        }
        else
        {
            return;
        }
    }

    private void BuyCheck()
    {
        for (int i = 0; i < BuySave.Instance.buyArray.Length; i++)
        {
            if (BuySave.Instance.buyArray[i])
            {
                btImage[i].color = Color.white;
            }
            else
            {
                btImage[i].color = Color.black;
            }
        }
    }

    private void SetDefault()
    {
        tgui.text = " ";
    }
}
