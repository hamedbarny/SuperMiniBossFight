using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Damage_Ability_3 : MonoBehaviour
{
    public static event Action<int> PlayerDamageDone;

    [SerializeField] Players playerSO;
    private int damage = 1;

    private void Awake()
    {
        damage = playerSO.hellFireDamage;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(7))
        {
            other.GetComponent<Bot_Health>().TakeDamage(damage);
            PlayerDamageDone?.Invoke(damage);
        }
    }
}
