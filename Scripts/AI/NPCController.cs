using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
	public float Speed;
	[Space]
	public bool StartOnPlayerTrigger;
	public bool TriggeredTrigger;
	[Space]
	public Transform[] Target;
	[Space]
	public int CurrentlyWalkingTo;
	public int LastTarget;
	[Space]
	public float CurrentlyWalkingToCordsX;
	public float CurrentlyWalkingToCordsY;
	[Space]
	public float LastTargetCordsX;
	public float LastTargetCordsY;
	[Space]
	public bool WalkingUp;
    public bool WalkingLeft;
    public bool WalkingDown;
    public bool WalkingRight;

	Animator PlayerAnimator;

	void Start()
	{
		PlayerAnimator = GetComponent<Animator> ();

		CurrentlyWalkingTo = 0;
		LastTarget = 0;
	}

	void Update()
	{
		ListeningForAnimations();
		//StartWalkingToTarget(Target[CurrentlyWalkingTo]);

		if (StartOnPlayerTrigger && TriggeredTrigger)
		{
			StartWalkingToTarget(Target[CurrentlyWalkingTo]);
		}
		if (!StartOnPlayerTrigger && !TriggeredTrigger)
		{
			StartWalkingToTarget(Target[CurrentlyWalkingTo]);
		}
	}


	void StartWalkingToTarget(Transform target)
	{
		float step = Speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);

		if (Mathf.Approximately(transform.position.x, target.position.x) && (Mathf.Approximately(transform.position.y, target.position.y)))
		{
			Debug.Log("Arrived At: " + target);
		    CurrentlyWalkingTo += 1;
			LastTarget = CurrentlyWalkingTo - 1;
		}
	}

	void ListeningForAnimations()
	{
		CurrentlyWalkingToCordsX = Target[CurrentlyWalkingTo].position.x;
		CurrentlyWalkingToCordsY = Target[CurrentlyWalkingTo].position.y;

	 	LastTargetCordsX = Target[LastTarget].position.x;
	 	LastTargetCordsY = Target[LastTarget].position.y;

		if (CurrentlyWalkingToCordsX > LastTargetCordsX)
		{
			WalkingUp    = false;
		    WalkingLeft  = false;
		    WalkingDown  = false;
		    WalkingRight = true;
		}

		if (CurrentlyWalkingToCordsX < LastTargetCordsX)
		{
			WalkingUp    = false;
		    WalkingLeft  = true;
		    WalkingDown  = false;
		    WalkingRight = false;
		}

		if (CurrentlyWalkingToCordsY > LastTargetCordsY)
		{
			WalkingUp    = true;
		    WalkingLeft  = false;
		    WalkingDown  = false;
		    WalkingRight = false;
		}

		if (CurrentlyWalkingToCordsY < LastTargetCordsY)
		{
			WalkingUp    = false;
		    WalkingLeft  = false;
		    WalkingDown  = true;
		    WalkingRight = false;
		}

		if (WalkingUp)
		{
			WalkUpAnim();
		}

		if (WalkingLeft)
		{
			WalkLeftAnim();
		}

		if (WalkingDown)
		{
			WalkDownAnim();
		}

		if (WalkingRight)
		{
			WalkRightAnim();
		}
	}

	void WalkRightAnim()
	{
		PlayerAnimator.SetBool("Up",    false);
		PlayerAnimator.SetBool("Left",  false);
		PlayerAnimator.SetBool("Down",  false);
		PlayerAnimator.SetBool("Right", true);
		PlayerAnimator.speed = 1;
	}

	void WalkLeftAnim()
	{
		PlayerAnimator.SetBool("Up",    false);
		PlayerAnimator.SetBool("Left",  true);
		PlayerAnimator.SetBool("Down",  false);
		PlayerAnimator.SetBool("Right", false);
		PlayerAnimator.speed = 1;
	}

	void WalkDownAnim()
	{
		PlayerAnimator.SetBool("Up",    false);
		PlayerAnimator.SetBool("Left",  false);
		PlayerAnimator.SetBool("Down",  true);
		PlayerAnimator.SetBool("Right", false);
		PlayerAnimator.speed = 1;
	}

	void WalkUpAnim()
	{
		PlayerAnimator.SetBool("Up",    true);
		PlayerAnimator.SetBool("Left",  false);
		PlayerAnimator.SetBool("Down",  false);
		PlayerAnimator.SetBool("Right", false);
		PlayerAnimator.speed = 1;
	}
}
