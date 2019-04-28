using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PopUpTextOnTrigger : MonoBehaviour
{
	public GameObject PopUp;
	public TextMeshPro BubbleText;

	[TextArea(3, 10)]
	public string Dialogue;

	private bool TypedOut;

	void Start()
	{
		PopUp.SetActive(false);
		TypedOut = false;
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		DisplayNPCText();
	}


	void OnTriggerExit2D(Collider2D collider)
	{
		EndNPCText();
	}

	public void DisplayNPCText()
	{
		PopUp.SetActive(true);

		if (TypedOut == false)
		{
			StartCoroutine(TypeSentence());
			TypedOut = true;
		}
	}

	public void EndNPCText()
	{
		//BubbleText.text = Dialogue;
		StopAllCoroutines();
		PopUp.SetActive(false);
	}


	IEnumerator TypeSentence()
	{
		BubbleText.text = "";
		foreach (char letter in Dialogue.ToCharArray())
		{
			BubbleText.text += letter;
			yield return null;
		}
	}
}
