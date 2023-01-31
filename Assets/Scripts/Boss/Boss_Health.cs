using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Health : Bot_Health
{
    public static event Action BossIsRaged;
    public static event Action<float> HealthPercentage;
    public static bool isBossStarted = false;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] Slider HP, Rage;
    [SerializeField] Bosses bossSO;
    private Animator _animator;
    private bool canTakeDamage;
    public bool CanTakeDamage
    {
        get { return canTakeDamage; }
        set { canTakeDamage = value; }
    }

    [SerializeField] float timeToRage=300;
    //timeer
    bool isRaged = false, flag = true, isStarted = false;
    float rageTime = 0;
    //timer

    private void Awake()
    {
        maxHealth = bossSO.health;
        canTakeDamage = true;
        currentHealth = maxHealth;
        HP.maxValue = maxHealth;
        HP.value = HP.maxValue;
        Rage.value = 0;
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (!isRaged && isStarted&& currentHealth > 0)
        {
            Start_Boss();
            if (rageTime <= timeToRage)
            {
                rageTime += Time.deltaTime;
                Rage.value = rageTime;
            }
            else
            {
                isRaged = true;
            }
        }
        if(isRaged && flag)
        {
            bossSO.fireBallDamage += 250;
            bossSO.kickDamage += 250;
            BossIsRaged?.Invoke();
            flag = false;
        }
    }
    public float Percentage()
    {
        return currentHealth * 100 / maxHealth; 
    }
    public override void TakeDamage(int damage)
    {
        if (canTakeDamage)
        {
            if (!isStarted) isStarted = true;
             currentHealth -= damage;
            HealthPercentage?.Invoke(Percentage());
            HP.value = currentHealth;
            if (currentHealth <= 0)
            {
                Dead();
            }
        }
    }
    public override void Dead()
    {
        _animator.SetTrigger("Dead");
        isBossStarted = false;
        gameOverPanel.SetActive(true);
        this.GetComponent<Collider>().enabled = false;
    }
    private void OnEnable()
    {
        Player_Health.PlayerDead += DanceBaby;
    }
    private void OnDisable()
    {
        Player_Health.PlayerDead -= DanceBaby;
    }

    private void DanceBaby()
    {
        _animator.SetTrigger("PlayerDead");
    }
    private void Start_Boss()
    {
        if (!isStarted)
        {
            isBossStarted = true;
            isStarted = true;
        }
    }
}
