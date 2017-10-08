using UnityEngine;
using System.Collections;

public class DialogueManager : MonoBehaviour {


	DialogueBoxManager dbm;
	int countvalue = 0; 
	string npccharactername;
	bool needtoendconvo;
	//String array of the conversation associated to a particular story lines.

	void initialiseconvo(string npccharacter){
		//Create dialogue instance associated with NPC character.
		//Not the best idea but have a separate method and do if-else statements based on the NPC character
		//Create an instance based on who the outcome is.
		//String [] *Character*Dialogue.getStoryLines;
		//if ^ == null {
		//	get a random line.
		//}else{
	//	string initialtext = retrievetexttodisplay();

	// }
		string initialtext = texttodisplay();
		npccharactername = npccharacter;
		dbm.StartConvo();
		needtoendconvo = false;
	}

	//Displaying appropriate text.
	void texttodisplay(){
		if (needtoendconvo) {
			dbm.EndConvo ();
		} else {
			string texttodisplay;
			texttodisplay = storylines [countvalue + 1] + ": " + storylines [countvalue];
			dbm.SayLine(texttodisplay);
			incrementcountvalue ();
		}
	}
		
	void incrementcountvalue(){
		//Checking if the conversation has ended or not.
		if (countvalue + 2 >= storylines.size ()) {
			needtoendconvo = true;
		//	dbm.EndConvo ();
		} 
		//When the convo needs to progress.
		else {
			countvalue += 2;
		}
	}

	/*void updatetexttodisplay(){
		dbm.SayLine();
	}*/



}
