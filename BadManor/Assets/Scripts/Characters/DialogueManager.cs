using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public GameObject dBox;
	public Text dText;

	private string[] dialogueLines;
	private int currentLine;
	// Use this for initialization

	public void StartConvo() {
		dialogueLines = new string[] {"This is line one", "This is my second line of dialog", "While am I still talking, this is my third line"};
		currentLine = -1;

		//dText.text = dialogueLines [currentLine];
		dBox.SetActive (true);
	}

	public bool NextLine()
	{
		currentLine++;
		if (currentLine >= dialogueLines.Length) 
		{
			return false;
		}
		dText.text = dialogueLines [currentLine];
		return true;
	}

	public void EndConvo() 
	{
		currentLine = 0;
		dBox.SetActive (false);
	}
}
