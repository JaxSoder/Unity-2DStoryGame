using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepSystem : MonoBehaviour {
	[Header("THIS OBJECT SHOULD BE ATTACHED TO PARENT")]
	[Header("BUT USE SEPARATE AUDIO SOURCE AS A CHILD AND ATTACH")]

	public AudioSource audioSource;
	public Animator anim;
	public float stepDelay;
	public AudioClip defaultClip;
	public AudioClip defaultClip1;
	public AudioClip defaultClip2;
	private AudioClip currentClip;
	private bool couroutineOn;

	void Start ()
	{
		anim = this.gameObject.GetComponent<Animator>();

		couroutineOn = true;
		audioSource.clip = defaultClip;

		StartCoroutine (Walking ());
	}

	IEnumerator Walking()
	{

		while (couroutineOn == true)
		{

			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("WalkUp") || anim.GetCurrentAnimatorStateInfo (0).IsName ("WalkDown") || anim.GetCurrentAnimatorStateInfo (0).IsName ("WalkLeft"))
			{

				int rand = Random.Range (0, 2);
				if (rand == 0)
				{
					currentClip = defaultClip;
				}
				 else if (rand == 1)
				{
					currentClip = defaultClip1;
				}
				 else
				{
					currentClip = defaultClip2;
				}

				audioSource.clip = currentClip;

				audioSource.Play ();

			} else
			{

				audioSource.Stop ();
			}

			yield return new WaitForSeconds (stepDelay);

		}
	}
}
