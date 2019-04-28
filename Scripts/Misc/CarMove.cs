using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
	public int Speed;

	public GameObject ObjectToMove;

	public float X;
	public float Y;

	void Start()
	{

	}

	void Update ()
	{
		transform.Translate(Vector3.left * Speed * Time.deltaTime, Space.World);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "CarTrigger1")
		{
			Debug.Log("AGHH");
			ObjectToMove.transform.position = new Vector3(X, Y, 0);
		}
	}
}
