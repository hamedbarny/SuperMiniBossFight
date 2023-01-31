using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_Health_Percent : MonoBehaviour
{
    TMP_Text txt;
    string percentage;
    private void Awake()
    {
        txt = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        Player_Health.HealthPercentage += UpdateText;
    }
    private void OnDisable()
    {
        Player_Health.HealthPercentage -= UpdateText;
    }

    protected void UpdateText(int Health)
    {
        percentage = (Health / 10).ToString()+"%";
        txt.SetText(percentage);
    }
}
