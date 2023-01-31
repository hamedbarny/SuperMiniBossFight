using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Color : MonoBehaviour
{

    private void OnEnable()
    {
        Boss_Health.BossIsRaged += RageColor;
    }
    private void OnDisable()
    {
        Boss_Health.BossIsRaged -= RageColor;
    }
    void RageColor()
    {
        GetComponent<SkinnedMeshRenderer>().material.color = Color.red;
    }
}
