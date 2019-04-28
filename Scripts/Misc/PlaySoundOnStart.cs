using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnStart : MonoBehaviour
{

	public AudioSource PlayerAudioSource;
	public AudioClip DoorSound;


	void Start ()
	{
		PlayerAudioSource.clip = DoorSound;
		PlayerAudioSource.Play();

	}
}
