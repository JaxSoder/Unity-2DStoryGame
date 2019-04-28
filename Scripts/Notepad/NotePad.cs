using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class NotePad : MonoBehaviour
{

	public GameObject PlayerGameObject;

	public Image NotePadUI;
	public bool NotePadVisible;

	AudioSource PlayerAudioSource;


	[Header("Animation Settings")]
	public Animator NotePadAnimator;
	public string NotePadCloseAnim;
	public string NotePadOpenAnim;

    [Header("Title Settings")]
 	public InputField TitleInputField;
	string TitleKey = "NotePadTitleText";
	public string NotePadTitle;

	[Header("Notes Settings")]
	public InputField NotesInputField;
	string NotesKey = "NotePadNotesText";
	public string NotePadNotes;

	[Header("CaseNum Settings")]
	public InputField CaseNumInputField;
	string CaseNumKey = "CaseNumNotesText";
	public string NotePadCaseNum;

	void Start ()
	{
		//NotePadCloseAnim = "NotePadCloseAnim";
		//NotePadOpenAnim = "NotePadOpenAnim" ;

		//Cursor.visible = false;
		UpdateNotesSave();
		NotePadInit();
	}

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.F1))
		{
			PlayerAudioSource.Play(0);
			//NotePadAnimator.Play(NotePadCloseAnim);
			//Cursor.visible = !Cursor.visible;
			NotePadVisible = !NotePadVisible;
		}

		if (NotePadVisible == true)
		{
			PlayerGameObject.GetComponent<PlayerController>().DisableMovement();
			NotePadUI.gameObject.SetActive(true);
		}
		if (NotePadVisible == false)
		{
			PlayerGameObject.GetComponent<PlayerController>().EnableMovement();
			NotePadUI.gameObject.SetActive(false);
		}
	}

	void NotePadInit()
	{
		PlayerAudioSource = GetComponent<AudioSource>();
		NotePadUI.gameObject.SetActive(false);
		NotePadVisible = false;

		//Saving Part Below
		var input1 = TitleInputField;
		var input2 = NotesInputField;
		var input3 = CaseNumInputField;
        var se1= new InputField.SubmitEvent();
		var se2= new InputField.SubmitEvent();
		var se3= new InputField.SubmitEvent();
    	se1.AddListener(SubmitTitle);
		se2.AddListener(SubmitNotes);
		se3.AddListener(SubmitCaseNum);
        input1.onEndEdit = se1;
		input2.onEndEdit = se2;
		input3.onEndEdit = se3;
	}

	void UpdateNotesSave()
	{
		PlayerPrefs.GetString(TitleKey);
		PlayerPrefs.GetString(NotesKey);
		PlayerPrefs.GetString(CaseNumKey);
		TitleInputField.text = PlayerPrefs.GetString(TitleKey);
		NotesInputField.text = PlayerPrefs.GetString(NotesKey);
		CaseNumInputField.text = PlayerPrefs.GetString(CaseNumKey);
	}


	private void SubmitTitle(string arg1)
    {
		NotePadTitle = arg1;

		Debug.Log("Saving "+ arg1 + " to NotesTitle");

		PlayerPrefs.SetString(TitleKey, NotePadTitle);
    }

	private void SubmitNotes(string arg2)
    {
		NotePadNotes = arg2;

		Debug.Log("Saving "+ arg2 + " to Notes");

		PlayerPrefs.SetString(NotesKey, NotePadNotes);
    }

	private void SubmitCaseNum(string arg3)
    {
		NotePadCaseNum = arg3;

		Debug.Log("Saving "+ arg3 + " to NotesCaseNum");

		PlayerPrefs.SetString(CaseNumKey, NotePadCaseNum);
    }
}
