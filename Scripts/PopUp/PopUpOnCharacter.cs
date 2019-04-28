using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PopUpOnCharacter : MonoBehaviour
{
	public GameObject PopUp;
	public TextMeshPro BubbleText;

	[TextArea(3, 10)]
	public string[] Sentences;

	public GameObject[] Triggers;


	void Start ()
	{
		EndText();
	}

	private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "CharacterPopUp0")
        {
			DisplayText(0);
			Invoke("EndText", 2);
			Triggers[0].SetActive(false);
        }

		if (other.tag == "CharacterPopUp1")
        {
			DisplayText(1);
			Invoke("EndText", 2);
			Triggers[1].SetActive(false);
        }

		if (other.tag == "CharacterPopUp2")
        {
			DisplayText(0);
			Invoke("EndText", 2);
			Triggers[0].SetActive(false);
        }

	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "CharacterPopUp0")
        {
			EndText();
        }

		if (other.tag == "CharacterPopUp1")
        {
			EndText();
        }

		if (other.tag == "CharacterPopUp2")
        {
			EndText();
        }
	}

	public void DisplayText(int SentenceArray)
	{
		BubbleText.text = Sentences[SentenceArray];
		PopUp.SetActive(true);

		StartCoroutine(TypeSentence(BubbleText.text));

	}

	public void EndText()
	{
		StopAllCoroutines();
		BubbleText.text = Sentences[2];
		PopUp.SetActive(false);
	}


	IEnumerator TypeSentence (string sentence)
	{
		BubbleText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			BubbleText.text += letter;
			yield return null;
		}
	}
}
