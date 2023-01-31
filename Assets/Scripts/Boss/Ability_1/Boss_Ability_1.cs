using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Ability_1 : MonoBehaviour
{
   
    [SerializeField] private Transform handTrans,rotationTrans;
    [SerializeField] private float _fireHeighOffset = 1;
    private Transform _player;


    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void OnEnable()
    {
        Boss_Ability_Call_1.BossAbilityCall_1 += BossAbility_1;
    }
    private void OnDisable()
    {
        Boss_Ability_Call_1.BossAbilityCall_1 -= BossAbility_1;
    }
    public void BossAbility_1()
    {
        transform.LookAt(_player);
        SpawnOrb();
    }

    private void SpawnOrb()
    {

        GameObject fireBall = Boss_Ability_Pooling_1.SharedInstance.GetPooledObject();
        if (fireBall != null)
        {
            fireBall.transform.SetPositionAndRotation(new Vector3(handTrans.position.x, _fireHeighOffset, handTrans.position.z), rotationTrans.rotation);
            fireBall.SetActive(true);
        }
    }
}
