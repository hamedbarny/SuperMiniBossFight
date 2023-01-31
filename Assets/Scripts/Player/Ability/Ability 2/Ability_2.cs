using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ability_2 : MonoBehaviour
{
    public static event Action<int> PlayerDamageDone;

    [SerializeField] Players playerSO;
    private int damage =1;

    private void Awake()
    {
        damage = playerSO.fireOrbDamage;
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
