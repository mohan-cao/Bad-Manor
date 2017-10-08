using UnityEngine;
using System.Collections;
using Assets.Scripts;
using Assets.Scripts.Characters;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour {

    private Dictionary<string, CharacterDialogue> characterDialogues = new Dictionary<string, CharacterDialogue>();

    // Instance of dialogue box for controlling view
	private DialogueBoxManager dbm;
	private int count = 0;

    private string[] storyLines;

	string npcCharacter;
	bool needtoendconvo;
    //String array of the conversation associated to a particular story lines.

        // Set up instances of Character Dialogue classes
    private void Start()
    {
        characterDialogues["Anvi"] = AnviDialogue.getInstance();
        characterDialogues["Brange"] = BrangeDialogue.getInstance();
        characterDialogues["Charles"] = CharlesDialogue.getInstance();
        characterDialogues["Maurice"] = MauriceDialogue.getInstance();
        characterDialogues["MiNa"] = MiNaDialogue.getInstance();
        characterDialogues["Sam"] = SamDialogue.getInstance();
    }

    public void StartConvo(string character){

        // Set all variables
        npcCharacter = character;
        count = 0;
        dbm = FindObjectOfType<DialogueBoxManager>();
        //GameManager.GameState gameState = GameManager.inst.currentState();

        //This is hardcoded for debugging use the line above instead
        GameManager.GameState gameState = GameManager.GameState.FIND_BERTHA;

        storyLines = characterDialogues[npcCharacter].getStoryLines(gameState);
        dbm.StartConvo();
        
	}

    // Displaying appropriate text.
    // Returns true if convo is still going (a line was said)
    // Returns false if convo has ended (so dialogue box has now closed)
    public bool NextLine() {

        // if character has no story during this game state and has already said one random line
        if (storyLines == null && count == 1)
        {
            // end the conversation
            EndConvo();
            return false;
        } // if character has no story during this game state and has not already said one random line
        else if (storyLines == null && count == 0)
        {
            // say the random line, increase count
            string line = characterDialogues[npcCharacter].getRandomLine();
            dbm.SayLine(line, npcCharacter);
            count++;
            return true;
        } // if character has storylines, but has finished all of them
        else if (count >= storyLines.Length - 1)
        {
            // end the conversation
            EndConvo();
            return false;
        } // if character has storylines and still has more lines left in converstaion
        else
        {
            // say the next line in convo and increase count
            string text = storyLines[count];
            count++;
            string name = storyLines[count];
            count++;

            dbm.SayLine(text, name);

            return true;
        }

	}

    void EndConvo()
    {
        dbm.EndConvo();
        count = 0;
        npcCharacter = null;
    }

}
