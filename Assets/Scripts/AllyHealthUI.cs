using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AllyHealthUI : MonoBehaviour
{
    AllyHealth[] allies;
    TextMeshProUGUI healthUI;

    void Start()
    {
       allies = FindObjectsOfType<AllyHealth>();
       healthUI = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        healthUI.text = "";
        foreach (AllyHealth ally in allies)
        {
            healthUI.text += ally.gameObject.name + ": " + ally.CurrHitPoints +"    ";
        }
    }
}
