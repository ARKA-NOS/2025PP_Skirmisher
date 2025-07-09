using System;
using NUnit.Framework;
using TMPro;
using UnityEngine;

public class StartPanelSet : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI day;
    [SerializeField] TextMeshProUGUI dayBt;

    [SerializeField] TextMeshProUGUI killC;
    [SerializeField] TextMeshProUGUI allKillC;

    [SerializeField] TextMeshProUGUI estimated;

    [SerializeField] TextMeshProUGUI costCouter;

    [SerializeField] TextMeshProUGUI cwn;
    [SerializeField] GameObject[] gunIArray;

    bool firstSet = true;

    private void Start()
    {
        day.text = $"DAY {DazenKillManager.Instance.Daze}";
        dayBt.text = $"계속하기 ( DAY {DazenKillManager.Instance.Daze} )";

        allKillC.text = $"전체 : {DazenKillManager.Instance.KillAll} 마리\r\n";
        killC.text = 
            $"러너 : {DazenKillManager.Instance.KillRunner} 마리\r\n" +
            $"스트라닉 : {DazenKillManager.Instance.KillStranik} 마리\r\n" +
            $"라트니크 : {DazenKillManager.Instance.KillRatnik} 마리\r\n" +
            $"크랩 : {DazenKillManager.Instance.KillCrab} 마리\r\n" +
            $"헌터 : {DazenKillManager.Instance.KillHunter} 마리\r\n";

        estimated.text = $"최소 {DazenKillManager.Instance.Daze * 3}마리 ~ 최대 {DazenKillManager.Instance.Daze * 3 + 4}마리";
        costCouter.text = $"{CostSystem.Instance.Cost}";

        Acttive();
        firstSet = false;
    }

    private void OnEnable()
    {
        if (!firstSet)
        {
            Acttive();
            costCouter.text = $"{CostSystem.Instance.Cost}";
        }
    }

    private void CWI(bool activate, string gunName, int num)
    {
        if (activate)
        {
            cwn.text = gunName;
            gunIArray[num].SetActive(true);

            for (int i = 0; i < gunIArray.Length; i++)
            {
                if (i != num)
                    gunIArray[i].SetActive(false);
            }
        }
    }

    public void Acttive()
    {
            CWI(GunsActivate.Instance.Glock19Activate, "Glock 19", 0);
            CWI(GunsActivate.Instance.M9A1Activate, "Beretta M9A1", 1);
            CWI(GunsActivate.Instance.DEActivate, "MRI Desert Eagle", 2);
            CWI(GunsActivate.Instance.UZIActivate, "IMI UZI", 3);
            CWI(GunsActivate.Instance.UMP40Activate, "H&k UMP-40", 4);
            CWI(GunsActivate.Instance.VectorActivate, "TDI KRISS Vector", 5);
            CWI(GunsActivate.Instance.Type56Activate, "NORINCO Type 56", 6);
            CWI(GunsActivate.Instance.M4A1Activate, "COLT M4A1", 7);
            CWI(GunsActivate.Instance.VHSD2Activate, "HS Produkt VHSD2", 8);
            CWI(GunsActivate.Instance.SA58Activate, "DS ARMS SA-58", 9);
            CWI(GunsActivate.Instance.AA12Activate, "AA-12", 10);
            CWI(GunsActivate.Instance.KordActivate, "ZiD Kord 12.7mm", 11);
    }
}
