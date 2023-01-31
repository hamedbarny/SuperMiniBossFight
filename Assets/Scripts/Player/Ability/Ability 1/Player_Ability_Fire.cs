using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Player_Ability_Fire : MonoBehaviour
{
    public static event Action<int> PlayerDamageDone;

    [SerializeField] Players playerSO;
    private int damage = 1;
    [SerializeField] GameObject mainEffect, explodeEffect;
    GameObject player;
    public float speed = 10f;
    bool hitTarget = false;
    Vector3 initPos, playerPos;
    Rigidbody rb;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(7))
        {
            other.gameObject.GetComponent<Bot_Health>().TakeDamage(damage);
            PlayerDamageDone?.Invoke(damage);
            hitTarget = true;
        }
        Destroyer();
    }

    private void Awake()
    {
        damage = playerSO.fireBallDamage;
        initPos= new Vector3();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void LateUpdate()
    {
        initPos = transform.position;
        if (Vector3.Distance(initPos, playerPos) > 10)
        {
            Destroyer();
        }
    }
    private void OnEnable()
    {
        hitTarget = false;
        initPos = transform.position;
        playerPos = player.transform.position;

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
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
    }

}
