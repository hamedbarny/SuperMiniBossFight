using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_3 : MonoBehaviour
{
    [SerializeField] private GameObject ability_3_Object;
    private void OnEnable()
    {
        Player_Ability_3.Ability_3_Fire += FireAbility_3;
    }
    private void OnDisable()
    {
        Player_Ability_3.Ability_3_Fire -= FireAbility_3;
    }

    void FireAbility_3(Vector3 pos)
    {
        ability_3_Object.transform.position = pos;
        ability_3_Object.SetActive(true);
        StartCoroutine(ToggleAbility_3());
    }

    IEnumerator ToggleAbility_3()
    {
        yield return new WaitForSeconds(4);
        ability_3_Object.SetActive(false);
    }
}
