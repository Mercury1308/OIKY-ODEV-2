using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TheEnd : MonoBehaviour
{
    public GameObject endText;
    //Normalde aktif olmayan oyun bitti yazısı biz oyun bitiş bölgesine girince aktifleşsin
    private void OnTriggerEnter()
    {
        endText.SetActive(true);
    }
}
