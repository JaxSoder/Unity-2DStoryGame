using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
	public GameObject NPC;

	public bool TempDisable;

	public NPCController NPCControllerScript;

	void Start()
	{
		NPCControllerScript = NPC.GetComponent<NPCController>();
		NPCControllerScript.TriggeredTrigger = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (TempDisable)
		{
			//Do Nothing
		}
		else
		{
			NPCControllerScript.TriggeredTrigger = true;
		}

	}
}
