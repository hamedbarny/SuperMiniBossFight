using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class FireBall_Damage : MonoBehaviour
{
    public static event Action<int> OnRangeHitPlayer;

    protected int attackDamage = 10;
    [SerializeField] float destroyTime = 0.2f;
    [SerializeField] protected GameObject mainEffect, explodeEffect;
    public float speed = 5f;
    bool hitTarget = false;
    protected Rigidbody rb;
    protected Vector3 initPos,currentPos;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(6))
        {
            OnRangeHitPlayer?.Invoke(attackDamage);
            hitTarget = true;
        }
        Destroyer();

    }
    private void Awake()
    {
        initPos = new Vector3();
        currentPos = new Vector3();
    }
    private void LateUpdate()
    {
        currentPos = transform.position;
        if (Vector3.Distance(initPos, currentPos) > destroyTime*50)
        {
            Destroyer();
        }
    }
    private void OnEnable()
    {
        initPos = transform.position;
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * speed, ForceMode.VelocityChange);
    }
    private void OnDisable()
    {
        explodeEffect.SetActive(false);
        mainEffect.SetActive(true);
    }
    void Destroyer()
    {
        rb.velocity = Vector3.zero;
        explodeEffect.SetActive(hitTarget);
        mainEffect.SetActive(false);
        StartCoroutine(DelayDisable());
    }
    IEnumerator DelayDisable()
    {
        yield return new WaitForSeconds(destroyTime);
        gameObject.SetActive(false);
    }
}
