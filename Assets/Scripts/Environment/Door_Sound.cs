using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Sound : MonoBehaviour
{
	[SerializeField] AudioClip doorAudio;
	private void OnDoorOpen(AnimationEvent animationEvent)
	{
		AudioSource.PlayClipAtPoint(doorAudio, this.transform.position, 0.6f);
	}
}
