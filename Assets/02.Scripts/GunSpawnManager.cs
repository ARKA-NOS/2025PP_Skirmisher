using System;
using UnityEngine;

public class GunSpawnManager : MonoBehaviour
{
    GunsActivate _ga;

    [SerializeField] GameObject[] hgs;
    [SerializeField] GameObject[] smgs;
    [SerializeField] GameObject[] rfs;
    [SerializeField] GameObject[] sgs;
    [SerializeField] GameObject[] mgs;

    private void Awake()
    {
        _ga = GameObject.FindGameObjectWithTag("GunsActivate").GetComponent<GunsActivate>();
    }

    private void Start()
    {
        SpawnCheck(hgs, 1, _ga.Glock19Activate, "Glock 19");
        SpawnCheck(hgs, 0, _ga.M9A1Activate, "Beretta M9A1");
        SpawnCheck(hgs, 2, _ga.DEActivate, "MRI Desert Eagle");
        SpawnCheck(smgs, 0, _ga.UZIActivate, "IMI UZI");
        SpawnCheck(smgs, 1, _ga.UMP40Activate, "H&k UMP-40");
        SpawnCheck(smgs, 2, _ga.VectorActivate, "TDI KRISS Vector");
        SpawnCheck(rfs, 0, _ga.Type56Activate, "NORINCO Type 56");
        SpawnCheck(rfs, 1, _ga.M4A1Activate, "COLT M4A1");
        SpawnCheck(rfs, 2, _ga.VHSD2Activate, "HS Produkt VHSD2");
        SpawnCheck(rfs, 3, _ga.SA58Activate, "DS ARMS SA-58");
        SpawnCheck(sgs, 0, _ga.AA12Activate, "AA-12");
        SpawnCheck(mgs, 0, _ga.KordActivate, "ZiD Kord 12.7mm");
    }

    private void SpawnCheck(GameObject[] array, int num, bool activate, string gunName)
    {
        if (activate)
        {
            Instantiate(array[num], gameObject.transform);
            UIUpdater.Instance.SetGunName(gunName);
        }
    }
}
