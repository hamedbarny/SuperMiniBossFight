using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Ability_3 : MonoBehaviour
{
    public static event Action<Vector3> Ability_3_Fire;

    [SerializeField] KeyBinding keySO;
    [SerializeField] Animator HUD_Animator;
    [SerializeField] Players playerSO;
    [SerializeField] private GameObject indicator;
    [SerializeField] private LayerMask ignoreLayer;
    [SerializeField] private float abilityRange = 10;
    Transform playerTrans;
    Vector3 pos;
    bool allowFire, allowAim, allowAct, isCanceled;
    RaycastHit hit;
    Transform cameraTransform;

    private void Awake()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        pos = new Vector3();
        allowAct = true;
        allowFire = false;
        allowAim = false;
    }
    void Update()
    {
        if (playerSO.canCast && Input.GetKeyDown(keySO.Ability_3_Key))
        {
            allowAim = true;
            isCanceled = false;
        }
        if (playerSO.canCast && Input.GetKeyUp(keySO.Ability_3_Key))
        {
            if (allowAct && !isCanceled)
            {
                allowFire = true;
            }
            allowAim = false;

        } 

        cameraTransform = Camera.main.transform;
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, abilityRange+20,~ignoreLayer))
        {
                indicator.SetActive(allowAim);
                IndicatorManager(pos);
                pos = hit.point;
        }
    }

    private void IndicatorManager(Vector3 _pos)
    {   
        float x = Mathf.Clamp(_pos.x, playerTrans.position.x - abilityRange, playerTrans.position.x + abilityRange);
        float z = Mathf.Clamp(_pos.z, playerTrans.position.z - abilityRange, playerTrans.position.z + abilityRange);
        _pos = new Vector3(x, 0.05f, z);

        Vector3 offSet = _pos - playerTrans.position;
        _pos = Vector3.ClampMagnitude(offSet, abilityRange / 4) + playerTrans.position;

        indicator.transform.position = _pos;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isCanceled = true;
            allowFire = false;
            allowAim = false;
        }
        else if (allowFire && !isCanceled) Fire_Ability_3(_pos);

    }

    private void Fire_Ability_3(Vector3 pos)
    {
        allowAct = false;
        allowFire = false;
        Ability_3_Fire?.Invoke(pos);
        StartCoroutine(ToggleAllowAction());
    }

    IEnumerator ToggleAllowAction()
    {
        HUD_Animator.SetTrigger("Ability_3");
        yield return new WaitForSeconds(15);
        allowAct = true;
    }
}
