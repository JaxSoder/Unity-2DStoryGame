using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float CurrentSpeed;
	public float WalkSpeed;
	public float RunSpeed;
	public bool IsSprinting;
	Animator PlayerAnimator;
	SpriteRenderer render;
	Rigidbody2D rigid;
	public bool controls = true;

	public string WalkUpAnimName;
	public string WalkRightAnimName;
	public string WalkDownAnimName;
	public string WalkLeftAnimName;

	void Start ()
	{
		PlayerInit();
	}
	void Update()
	{
		CheckSprinting();
	}

	void FixedUpdate()
	{

		if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f)
		{
			transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * CurrentSpeed * Time.deltaTime, 0f, 0f));
		}

		if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f)
		{
			transform.Translate (new Vector3 (0f, Input.GetAxisRaw ("Vertical") * CurrentSpeed * Time.deltaTime, 0f));
		}

			//Animations
			if (Input.GetAxisRaw ("Horizontal") > 0)
			{
				WalkRightAnim();
			}
			else if (Input.GetAxisRaw ("Horizontal") < 0)
			{
				WalkLeftAnim();
			}
			else if (Input.GetAxisRaw ("Vertical") < 0)
			{
				WalkDownAnim();
			}
			else if (Input.GetAxisRaw ("Vertical") > 0)
			{
				WalkUpAnim();
		}
		else
		{
			PlayerAnimator.speed = 0;
		}
	}

	public void PlayerInit()
	{
		CurrentSpeed = WalkSpeed;
		PlayerAnimator = GetComponent<Animator> ();
		render = GetComponent<SpriteRenderer> ();
		rigid = GetComponent<Rigidbody2D> ();
	}

	public void CheckSprinting()
	{
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			CurrentSpeed = RunSpeed;
			IsSprinting = true;

		}
		if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			CurrentSpeed = WalkSpeed;
			IsSprinting = false;
		}
	}

	public void WalkRightAnim()
	{
		PlayerAnimator.SetBool(WalkUpAnimName, false);
		PlayerAnimator.SetBool(WalkLeftAnimName, false);
		PlayerAnimator.SetBool(WalkDownAnimName, false);
		PlayerAnimator.SetBool(WalkRightAnimName, true);
		//----------------------------------------
		PlayerAnimator.SetBool("Up", false);
		PlayerAnimator.SetBool("Left", false);
		PlayerAnimator.SetBool("Down", false);
		PlayerAnimator.SetBool("Right", true);
		PlayerAnimator.speed = 1;
	}

	public void WalkLeftAnim()
	{
		PlayerAnimator.SetBool(WalkUpAnimName, false);
		PlayerAnimator.SetBool(WalkLeftAnimName, true);
		PlayerAnimator.SetBool(WalkDownAnimName, false);
		PlayerAnimator.SetBool(WalkRightAnimName, false);
		//-------------------------------------
		PlayerAnimator.SetBool("Up", false);
		PlayerAnimator.SetBool("Left", true);
		PlayerAnimator.SetBool("Down", false);
		PlayerAnimator.SetBool("Right", false);
		PlayerAnimator.speed = 1;
	}

	public void WalkDownAnim()
	{
		PlayerAnimator.SetBool(WalkUpAnimName, false);
		PlayerAnimator.SetBool(WalkLeftAnimName, false);
		PlayerAnimator.SetBool(WalkDownAnimName, true);
		PlayerAnimator.SetBool(WalkRightAnimName, false);
		//---------------------------------------------
		PlayerAnimator.SetBool("Up",    false);
		PlayerAnimator.SetBool("Left",  false);
		PlayerAnimator.SetBool("Down",  true);
		PlayerAnimator.SetBool("Right", false);
		PlayerAnimator.speed = 1;
	}

	public void WalkUpAnim()
	{
		PlayerAnimator.SetBool(WalkUpAnimName,    true);
		PlayerAnimator.SetBool(WalkLeftAnimName,  false);
		PlayerAnimator.SetBool(WalkDownAnimName,  false);
		PlayerAnimator.SetBool(WalkRightAnimName, false);
		//----------------------------------------------
		PlayerAnimator.SetBool("Up",    true);
		PlayerAnimator.SetBool("Left",  false);
		PlayerAnimator.SetBool("Down",  false);
		PlayerAnimator.SetBool("Right", false);
		PlayerAnimator.speed = 1;
	}

	public void DisableMovement()
	{
		GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
	}

	public void EnableMovement()
	{
		GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
	}
}
