using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    public static event Action PlayerHitEffect, PlayerDead;
    public static event Action<int> HealthPercentage;
    public static event Action<int> DamageTaken;
    [SerializeField] GameObject gameOverPanel;
    private bool isAlive;
    [SerializeField] Players playerSO;
    private int health = 100;
    Animator _animator;
    [SerializeField] Slider _slider;

    private void Awake()
    {
        playerSO.canCast = true;
        health = playerSO.health;
        isAlive = true;
        _animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void OnEnable()
    {
        FireBall_Damage.OnRangeHitPlayer += TakeDamage;
        Bot_Ability_Melee.OnMeleeHitPlayer += TakeDamage;
        Boss_Ability_3.OnBossKickHitPlayer += TakeDamage;

    }
    private void OnDisable()
    {
        FireBall_Damage.OnRangeHitPlayer -= TakeDamage;
        Bot_Ability_Melee.OnMeleeHitPlayer -= TakeDamage;
        Boss_Ability_3.OnBossKickHitPlayer -= TakeDamage;

    }
    public void TakeDamage(int damage)
    {
        if (isAlive)
        {
            PlayerHitEffect?.Invoke();
            health -= damage;
            HealthPercentage?.Invoke(health);
            DamageTaken?.Invoke(damage);
            _slider.value = health;
            if (health <= 0)
            {
                Dead();
            }
        }
    }

    void Dead()
    {
        isAlive = false;
        _animator.SetTrigger("Dead");
        gameOverPanel.SetActive(true);
        PlayerDead?.Invoke();
   
    }
}
