using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosOnTrigger : MonoBehaviour
{
	public GameObject Player;
	public float X;
	public float Y;

	public AudioSource AudioSource;
	public AudioClip DoorClip;

	void OnTriggerEnter2D(Collider2D collider)
	{
		Player.transform.position = new Vector3(X, Y, 0);

		AudioSource.clip = DoorClip;
		AudioSource.Play();
	}

}
