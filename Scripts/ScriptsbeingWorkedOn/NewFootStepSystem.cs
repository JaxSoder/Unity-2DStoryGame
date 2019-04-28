using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFootStepSystem : MonoBehaviour
{
	Rigidbody2D rb;
	public AudioSource AudioSource;
	public AudioClip WalkClip;

    private float t = 0.0f;
    public bool moving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            moving = true;
        }

        if (moving)
        {
            // when the cube has moved over 1 second report it's position
            t = t + Time.deltaTime;
            if (t > 1.0f)
            {
                Debug.Log(gameObject.transform.position.y + " : " + t);
                t = 0.0f;
            }
        }
    }
}
