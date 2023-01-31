using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Ability_2 : MonoBehaviour
{
    [SerializeField] KeyBinding keySO;
    [SerializeField] Animator HUD_Animator;
    [SerializeField] Players playerSO;
    bool allowFire = true;
    Animator _playerAnimator;
    [SerializeField] GameObject ability_2;
    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ability_2.transform.SetParent(player.transform);
        ability_2.SetActive(false);
    }
    private void Start()
    {  
        _playerAnimator = player.GetComponent<Animator>();
    }
    void Update()
    {
        if (playerSO.canCast && Input.GetKey(keySO.Ability_2_Key) && allowFire)
        {
            CastAbility();
        }
    }

    private void CastAbility()
    {
        StartCoroutine(ToggleAbility());
        ability_2.SetActive(true);
    }

    IEnumerator ToggleAbility()
    {
        _playerAnimator.SetTrigger("Ability2");
        HUD_Animator.SetTrigger("Ability_2");
        allowFire = false;
        yield return new WaitForSeconds(3);
        ability_2.SetActive(false);
        allowFire = true;
        //_playerAnimator.ResetTrigger("Ability2");
    }
}
