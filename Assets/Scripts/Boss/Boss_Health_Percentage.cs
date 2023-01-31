using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Boss_Health_Percentage : MonoBehaviour
{
    TMP_Text txt;
    string percentage;
    private void Awake()
    {
        txt = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        Boss_Health.HealthPercentage += UpdateText;
    }
    private void OnDisable()
    {
        Boss_Health.HealthPercentage -= UpdateText;

    }
    protected void UpdateText(float Health)
    {
        percentage = (Health).ToString() + "%";
        txt.SetText(percentage);
    }
}
