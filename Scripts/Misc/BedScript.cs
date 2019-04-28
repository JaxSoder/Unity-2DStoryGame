using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BedScript : MonoBehaviour
{

	public bool CanGoToSleep;
	public bool InTrigger;
	[Space]
	public string SceneToLoadTo;
	[Space]
	public int SubTime;
	public int WaitTime;
	[Space]
	public GameObject TriggerBox;
	private BoxCollider2D BoxCol;
	[Space]
	public GameObject PopUp;

	void Start()
	{
		BoxCol = TriggerBox.GetComponent<BoxCollider2D>();
		BoxCol.enabled = false;

		PopUp.SetActive(false);

	}

	void Update()
	{
		WaitTime -= SubTime;

		if (WaitTime <= 0)
		{
			SubTime = 0;
			CanGoToSleep = true;
		}

		if (CanGoToSleep)
		{
			BoxCol.enabled = true;
		}

		if (InTrigger && CanGoToSleep)
		{
			PopUp.SetActive(true);
		}
		else
		{
			PopUp.SetActive(false);
		}

		if (CanGoToSleep && InTrigger && Input.GetKeyDown(KeyCode.E))
		{
			Initiate.Fade(SceneToLoadTo, Color.black, 2.0f);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		InTrigger = true;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		InTrigger = false;
	}
}
