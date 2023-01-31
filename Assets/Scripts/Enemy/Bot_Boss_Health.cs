using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bot_Boss_Health : Bot_Health
{
    public static event Action Bot_Boss_Dead;
    private void OnEnable()
    {
        currentHealth = maxHealth;
        GetComponent<Collider>().enabled = true;
    }
    public override void Dead()
    {
        Bot_Boss_Dead?.Invoke();
        GetComponent<Animator>().SetTrigger("Death");
        //this.gameObject.SetActive(false);
    }
}
