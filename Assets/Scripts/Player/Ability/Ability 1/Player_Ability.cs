using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Ability : MonoBehaviour
{
    [SerializeField] KeyBinding keySO;
    [SerializeField] Animator HUD_Animator;
    [SerializeField] Players playerSO;
    public Transform cameraRootTrans;
    public Transform handTrans;
    public float _fireHeighOffset = 1f;
    public float _fireRate1 = 1f;

    Animator _animator;
    bool allowFire1 = true;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (playerSO.canCast && Input.GetKey(keySO.Ability_1_Key) && allowFire1)
        {
            _animator.SetTrigger("Ability1");
            HUD_Animator.SetTrigger("Ability_1");
            StartCoroutine(FireRate1());
        }

    }
    public void PlayerAbility1()
    {
        GameObject fireBall = Ability_Pooling_1.SharedInstance.GetPooledObject();
        _animator.ResetTrigger("Ability1");
        if (fireBall != null)
        {
            fireBall.transform.SetPositionAndRotation(new Vector3(handTrans.position.x, _fireHeighOffset, handTrans.position.z), cameraRootTrans.rotation);
            fireBall.SetActive(true);
        }
    }

    IEnumerator FireRate1()
    {
        allowFire1 = false;
        yield return new WaitForSeconds(_fireRate1);
        allowFire1 = true;
    }

}
