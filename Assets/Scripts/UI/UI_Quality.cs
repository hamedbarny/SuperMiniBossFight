using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Quality : MonoBehaviour
{
    public void Btn_LowQuality()
    {
        SetQuality(0);
    }
    public void Btn_MediumQuality()
    {
        SetQuality(3);
    }
    public void Btn_HighQuality()
    {
        SetQuality(5);
    }

    private void SetQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }
}
