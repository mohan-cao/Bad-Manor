using UnityEngine;
using System.Collections;

public class DialogueHolder : MonoBehaviour {

	public string dialogue;
	private DialogueManager dMan;
	public string[] dialogueLines;

	// Use this for initialization
	void Start () {
		dMan = FindObjectOfType<DialogueManager> ();
		//player = GetComponentsInParent<Player>();
	}

	void OnTriggerStay2D(Collider2D other){
		Debug.Log ("OnTriggerStay2D " + other.gameObject.tag);
		if (other.gameObject.tag == "NPC") {
			if (Input.GetKeyUp(KeyCode.Space)) {
				Debug.Log ("STARTING CONVO IN DIALOG HOLDER");
				dMan.StartConvo ();
				//player.SetIsConvo (true);
			}
		
		}
		
	}

}
