using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

	public Transform Target;
	public Vector3 Offset = new Vector3 (0f, 0f, -10f);

	void Start ()
	{
		Target = GameObject.Find ("Player").GetComponent<Transform>();
	}

	void FixedUpdate ()
	{
		transform.position = Target.position ;
	}
}
