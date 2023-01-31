using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Boss_Ability_3 : MonoBehaviour
{
    bool isTimeToDamage = true;
    public static event Action<int> OnBossKickHitPlayer;
    [SerializeField] Bosses bossSO;
    private int kickAttackDamage = 10;
    [SerializeField] private Transform feetTrans;
    private void OnEnable()
    {
        Boss_Health.BossIsRaged += UpdateStats;
    }
    private void OnDisable()
    {
        Boss_Health.BossIsRaged += UpdateStats;
    }
    private void Awake()
    {
        UpdateStats();
        transform.SetParent(feetTrans);
        transform.SetPositionAndRotation(feetTrans.position, feetTrans.rotation);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6 && isTimeToDamage)
        {
            StartCoroutine(TimeToDamageWait());
            OnBossKickHitPlayer?.Invoke(kickAttackDamage);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 6 && isTimeToDamage)
        {
            StartCoroutine(TimeToDamageWait());
            OnBossKickHitPlayer?.Invoke(kickAttackDamage);
        }
    }

    void UpdateStats()
    {
        kickAttackDamage = bossSO.kickDamage;
    }
    IEnumerator TimeToDamageWait()
    {
        isTimeToDamage = false;
        yield return new WaitForSeconds(0.5f);
        isTimeToDamage = true;
    }

}
