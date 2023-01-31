using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Audio_Manager : MonoBehaviour
{
	bool isTimeToTalk = true;
	[Range(0, 1)] public float volume;
	[SerializeField] AudioClip[] trashTalkAudios;
	[SerializeField] AudioClip startingAudio, roarAudio, laughAudio, abilityAudio_1, summonAudio, shieldAudio,deathAudio,spinAudio;
	Transform playerTrans;
    private void Awake()
    {
		playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
    }
    //Phase1
    private void Boss_Roar(AnimationEvent animationEvent) => AudioSource.PlayClipAtPoint(roarAudio, playerTrans.position, volume);
	private void Boss_Laugh(AnimationEvent animationEvent) => AudioSource.PlayClipAtPoint(laughAudio, playerTrans.position, volume);
	private void Boss_Ability_1(AnimationEvent animationEvent) => AudioSource.PlayClipAtPoint(abilityAudio_1, playerTrans.position, volume);
	private void Starting(AnimationEvent animationEvent) => AudioSource.PlayClipAtPoint(startingAudio, playerTrans.position, volume);

	//Phase2
	private void Boss_Summon(AnimationEvent animationEvent) => AudioSource.PlayClipAtPoint(summonAudio, playerTrans.position, volume);
	private void Boss_Shield(AnimationEvent animationEvent) => AudioSource.PlayClipAtPoint(shieldAudio, playerTrans.position, volume);

	//Phase3
	private void Boss_Spin(AnimationEvent animationEvent) => AudioSource.PlayClipAtPoint(spinAudio, playerTrans.position, volume);


	//Death
	private void Boss_Death(AnimationEvent animationEvent) => AudioSource.PlayClipAtPoint(deathAudio, playerTrans.position, volume);


	private void Update()
    {
		if (Boss_Health.isBossStarted && isTimeToTalk)
		{
			TrashTalk();
			StartCoroutine(TrashTalkWait());
		}
    }
    private void TrashTalk()
	{
		if (trashTalkAudios.Length > 0)
		{
			var index =Random.Range(0, trashTalkAudios.Length);
			AudioSource.PlayClipAtPoint(trashTalkAudios[index], playerTrans.position, volume);
		}
	}
	IEnumerator TrashTalkWait()
    {
		isTimeToTalk = false;
		yield return new WaitForSeconds(7);
		isTimeToTalk = true;
	}

}
