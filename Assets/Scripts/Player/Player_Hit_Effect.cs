using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class Player_Hit_Effect : MonoBehaviour
{
    [SerializeField] private GameObject hitEffect;
    [SerializeField] AudioClip DeathAudio;
    [SerializeField] AudioClip[] hitAudioClips;
    [SerializeField] [Range(0,1)] float audioVolume;
    private CinemachineImpulseSource cinemaImpulse;
    private Animator _animator;
    bool isAudioPlaying = false;
    private void Awake()
    {
        cinemaImpulse = hitEffect.GetComponent<CinemachineImpulseSource>();
        _animator = hitEffect.GetComponent<Animator>();
    }
    private void OnEnable()
    {
        Player_Health.PlayerHitEffect += HitEffect;
    }
    private void OnDisable()
    {
        Player_Health.PlayerHitEffect -= HitEffect;
    }
    void HitEffect()
    {
        OnHitSound();
        StartCoroutine(ToggleAnimator());
        cinemaImpulse.GenerateImpulse();
    }
    private void Player_Death(AnimationEvent animationEvent) => AudioSource.PlayClipAtPoint(DeathAudio, transform.position, audioVolume);
    private void OnHitSound()
    {
        if (hitAudioClips.Length > 0 && !isAudioPlaying)
        {
            var index = UnityEngine.Random.Range(0, hitAudioClips.Length);
            AudioSource.PlayClipAtPoint(hitAudioClips[index], transform.position, audioVolume);
        }
    }

    IEnumerator ToggleAnimator()
    {
        isAudioPlaying = true;
        _animator.SetTrigger("Hited");
        yield return new WaitForSeconds(.2f);
        _animator.ResetTrigger("Hited");
        isAudioPlaying = false;
    }

}
