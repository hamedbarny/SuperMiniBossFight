using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Boss_Ability_Call_2 : MonoBehaviour
{
    [SerializeField] private GameObject shield;
    [SerializeField] private Transform spawnLoc1, spawnLoc2;
    [SerializeField] private int spawnCounterSetting = 10;
    private int deadCounter = 0, spawnCounter = 0;
    private Animator _animator;
    private Transform _player;
    private bool isPhaseComp ;

    private void OnEnable()
    {
        Bot_Boss_Health.Bot_Boss_Dead += Bot_Boss_Dead_Counter;
    }
    private void OnDisable()
    {
        Bot_Boss_Health.Bot_Boss_Dead -= Bot_Boss_Dead_Counter;
    }

    private void Bot_Boss_Dead_Counter()
    {
        deadCounter++;
    }

    private void Awake()
    {
        isPhaseComp = false;
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _animator = this.GetComponent<Animator>();
    }

    private void Update()
    {
        if (spawnCounter >= spawnCounterSetting)
        {
            _animator.SetTrigger("Shield");
            spawnCounter = 0;

        }
        if (!isPhaseComp && (deadCounter >= spawnCounterSetting * 2))
        {
            // spawnCounter = 0;
            _animator.SetInteger("Phase2", 3);
            ShieldDown();
            isPhaseComp = true;
        }
        if (isPhaseComp && (deadCounter >= spawnCounterSetting * 4))
        {
            _animator.SetInteger("Phase3", 1);
            deadCounter = 0;
            ShieldDown();
            isPhaseComp = false;

        }
    }

    public void ShiledUp()
    {
        shield.SetActive(true);
    }
    public void ShieldDown()
    {
        shield.SetActive(false);
    }

    public void BossAbility_2()
    {
        transform.LookAt(_player);
        spawnCounter++;
        SpawnBots();
    }

    private void SpawnBots()
    {
        ShieldDown();
        GameObject bot = Boss_Ability_Pooling_2.SharedInstance.GetPooledObject();
        if (bot != null)
        {
            bot.transform.SetPositionAndRotation(spawnLoc1.position, spawnLoc1.rotation);
            bot.SetActive(true);
        }
        bot = Boss_Ability_Pooling_2.SharedInstance.GetPooledObject();
        if (bot != null)
        {
            bot.transform.SetPositionAndRotation(spawnLoc2.position, spawnLoc2.rotation);
            bot.SetActive(true);
        }
    }
}
