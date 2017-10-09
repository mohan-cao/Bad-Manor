using UnityEngine;
using System.Collections;
using Assets.Scripts;
using Assets.Scripts.Characters;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    private Dictionary<string, CharacterDialogue> characterDialogues = new Dictionary<string, CharacterDialogue>();
    
    private int timesTalked = 0;
    
	private int count = 0;

    private string[] storyLines;

	string npcCharacter;
	bool needtoendconvo;
    
    public GameObject dBox;
    public Text dText;
    //String array of the conversation associated to a particular story lines.

        // Set up instances of Character Dialogue classes
    private void Start()
    {
        characterDialogues["Anvi"] = AnviDialogue.getInstance();
        characterDialogues["Brange"] = BrangeDialogue.getInstance();
        characterDialogues["Charles"] = CharlesDialogue.getInstance();
        characterDialogues["Maurice"] = MauriceDialogue.getInstance();
        characterDialogues["Mi Na"] = MiNaDialogue.getInstance();
        characterDialogues["Sam"] = SamDialogue.getInstance();
    }

    public void StartConvo(string character){
        Debug.Log(character);
        Debug.Log(GameManager.inst.currentState());
        
        // Set all variables
        npcCharacter = character;
        count = 0;
        GameManager.GameState gameState = GameManager.inst.currentState();

        //This is hardcoded for debugging use the line above instead
        //GameManager.GameState gameState = GameManager.GameState.FIND_BERTHA;
        Debug.Log(GameManager.inst.currentState());
        storyLines = characterDialogues[npcCharacter].getStoryLines(gameState);
        dBox.SetActive (true);
    }

    // Displaying appropriate text.
    // Returns true if convo is still going (a line was said)
    // Returns false if convo has ended (so dialogue box has now closed)
    public bool NextLine() {
        Debug.Log("HELLO, THE COUNT FOR THE CONVO IS " + count);
        // if character has no story during this game state and has already said one random line
        if (storyLines == null && count == 1)
        {
            // end the conversation
            //EndConvo();
            //return false;
            string line = characterDialogues[npcCharacter].getRandomLine();
            dText.text = characterDialogues[npcCharacter].getName() + ": " + line;
            return true;
        } // if character has no story during this game state and has not already said one random line
        else if (storyLines == null && count == 0)
        {
            // say the random line, increase count
            string line = characterDialogues[npcCharacter].getRandomLine();
            dText.text = characterDialogues[npcCharacter].getName() + ": " + line;
            count++;
            return true;
        } // if character has storylines, but has finished all of them
        else if (count >= storyLines.Length - 1)
        {
            // end the conversation
            //EndConvo();
            //return false;
            string line = characterDialogues[npcCharacter].getRandomLine();
            dText.text = characterDialogues[npcCharacter].getName() + ": " + line;
            return true;
        } // if character has storylines and still has more lines left in converstaion
        else
        {
            // say the next line in convo and increase count
            string text = storyLines[count];
            count++;
            string name = storyLines[count];
            count++;

            dText.text = name + ": " + text;

            return true;
        }

	}

    public void EndConvo()
    {
        
        if (GameManager.inst.currentState() == GameManager.GameState.INVESTIGATE_EVIDENCE && npcCharacter.Equals("Mi Na"))
        {
            Debug.Log("WE'VE HIT THE END........SYKE");
            GameManager.inst.worldM.openCharlesRoom();
        }
        
        Debug.Log("END CONVO");
        dBox.SetActive (false);
        npcCharacter = null;
        
        
        switch (timesTalked)
        {
            case 0:
            {
                GameManager.inst.worldM.secondTutorial();
                break;
            }
            case 1:
            {
                GameManager.inst.worldM.finalTutorial();
                break;
            }
            case 2:
            {
                GameManager.inst.worldM.sampleItem();
                break;
            }
        }
        timesTalked++;
    }

}
