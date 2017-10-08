using UnityEngine;
using System.Collections;
using Assets.Scripts;
using Assets.Scripts.Characters;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour {

    private Dictionary<string, CharacterDialogue> characterDialogues = new Dictionary<string, CharacterDialogue>();

	private DialogueBoxManager dbm;
	private int count = 0;

    private string[] storyLines;

	string npcCharacter;
	bool needtoendconvo;
    //String array of the conversation associated to a particular story lines.

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

        npcCharacter = character;
        dbm = FindObjectOfType<DialogueBoxManager>();
        //GameManager.GameState gameState = GameManager.inst.currentState();

        //This is hardcoded for debugging use the line above instead
        GameManager.GameState gameState = GameManager.GameState.FIND_BERTHA;

        storyLines = characterDialogues[npcCharacter].getStoryLines(gameState);
        dbm.StartConvo();
        
	}

    //Displaying appropriate text.
    public bool NextLine() {

        if (storyLines == null && count == 1)
        {
            EndConvo();
            return false;
        } else if (storyLines == null && count == 0)
        {
            string line = characterDialogues[npcCharacter].getRandomLine();
            dbm.SayLine(line, npcCharacter);
            count++;
            return true;
        } else if (count >= storyLines.Length - 1)
        {
            EndConvo();
            return false;
        } else
        {
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
