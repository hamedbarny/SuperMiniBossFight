using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Ability_Call_3 : MonoBehaviour
{
    [SerializeField] GameObject ability_3_Collider;
    [SerializeField] GameObject shield;

    private void OnEnable()
    {
        ability_3_Collider.SetActive(true);
        shield.SetActive(false);
    }
    private void OnDisable()
    {
        ability_3_Collider.SetActive(false);

    }
}
