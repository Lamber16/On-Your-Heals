using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AllyHealthUI : MonoBehaviour
{
    [SerializeField] CharacterHealth[] allies;
    TextMeshProUGUI healthUI;

    void Start()
    {
       healthUI = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        healthUI.text = "";
        foreach (CharacterHealth ally in allies)
        {
            healthUI.text += ally.gameObject.name + ": " + ally.HitPoints +"    ";
        }
    }
}
