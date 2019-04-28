using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChangeSceneOnAddress : MonoBehaviour
{
	public GameObject PlayerGameObject;

	public GameObject AddressGameObject;
	public InputField AddressInputField;
	public Button SubmitButton;

	public List<string> AddressList = new List<string>();

	void Start()
	{
		SubmitButton.onClick.AddListener(TaskOnClick);
		AddressList.Add("1234 CandyLane");
		AddressGameObject.SetActive(false);
	}

	void TaskOnClick()
	{
		if (AddressInputField.text == "1234 CandyLane")
		{
			//PutChangeSceneCodeHereJackDontForgetYouDumbo
			Debug.Log("ChangingScene");
		}
		else
		{
			Debug.Log("This Address Doesnt Exist");
		}
	}

	void Update()
	{
		if (AddressInputField.isFocused == true)
		{
			PlayerGameObject.GetComponent<PlayerController>().DisableMovement();
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//Cursor.visible = true;
		DisplayAddressChangeGUI(true);
	}

	void OnTriggerExit2D(Collider2D other)
	{
		//Cursor.visible = false;
		DisplayAddressChangeGUI(false);
	}

	void DisplayAddressChangeGUI(bool displayed)
	{
		AddressGameObject.SetActive(displayed);
	}
}
