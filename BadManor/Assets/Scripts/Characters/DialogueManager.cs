using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public GameObject dBox;
	public Text dText;
	public bool dialogActive;

	public string[] dialogueLines;
	public int currentLine;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (dialogActive && Input.GetKeyDown(KeyCode.Space)) {
		//	dBox.SetActive (false);
		//		dialogActive = false;
			currentLine++;
		}

		if(currentLine >= dialogueLines.Length){
				dBox.SetActive (false);
					dialogActive = false;
			currentLine = 0;
		}

		dText.text = dialogueLines [currentLine];
	}

	public void ShowBox(string dialogue){
		dialogActive = true;
		dBox.SetActive (true);
		dText.text = dialogue;	
	}

	public void ShowDialogue(){
		dialogActive = true;
		dBox.SetActive (true);
	}
}
