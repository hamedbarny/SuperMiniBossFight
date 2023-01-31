using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Fireball : FireBall_Damage
{
    [SerializeField] Bosses bossSo;

    private void OnEnable()
    {
        Boss_Health.BossIsRaged += UpdateStats;
        initPos = transform.position;
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * speed, ForceMode.VelocityChange);
    }
    private void OnDisable()
    {
        Boss_Health.BossIsRaged -= UpdateStats;
        rb.velocity = Vector3.zero;
        transform.position = initPos;
        explodeEffect.SetActive(false);
        mainEffect.SetActive(true);
    }
    private void Awake()
    {
        UpdateStats();
    }
    void UpdateStats()
    {
        attackDamage = bossSo.fireBallDamage;
    }
}
