using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SimpleChangeSceenOnTrigger : MonoBehaviour
{
	public string SceneToLoad;


	void OnTriggerEnter2D(Collider2D other)
	{
		Initiate.Fade(SceneToLoad, Color.black, 2.0f);
	}

}
