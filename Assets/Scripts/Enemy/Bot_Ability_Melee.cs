using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Bot_Ability_Melee : Bot_Ability
{
    [SerializeField] AudioClip swordAudioClip;
    public static event Action<int> OnMeleeHitPlayer;
    [SerializeField] private Transform hitPoint;
    [SerializeField] private Enemy enemySO;
    private int attackDamage;

    private void Awake()
    {
        attackDamage = enemySO.attackDamage;
    }
    public override void Attack()
    {
        Collider[] an = Physics.OverlapSphere(hitPoint.position, 1f);
        foreach(Collider col in an)
        {
            AudioSource.PlayClipAtPoint(swordAudioClip, transform.position, 0.4f);
            if (col.gameObject.layer.Equals(6))
            {
                 OnMeleeHitPlayer?.Invoke(attackDamage);
            }
        }
    }


}