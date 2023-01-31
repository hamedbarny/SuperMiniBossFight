using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bot_Health : MonoBehaviour
{
    public static event Action Bot_Dead;
    //private Animator _animator;
    public int maxHealth = 50, currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
        //_animator = GetComponent<Animator>();
    }
    virtual public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Dead();
        }
    }

    virtual public void Dead()
    {
        Bot_Dead?.Invoke();
        GetComponent<Animator>().SetTrigger("Death");
        //Destroy(this.gameObject);
    }

}
