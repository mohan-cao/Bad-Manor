﻿using System;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the dialogue from interacting with items and NPCs, responsible for iniating and continuing.</summary>
[Serializable()]
public class DialogueManager : MonoBehaviour
{
    /// <summary>
    /// All dialogues.</summary>
    private Dictionary<string, CharacterDialogue> characterDialogues = new Dictionary<string, CharacterDialogue>();

    /// <summary>
    /// Used to check how many people talked to for tutorial level.</summary>
    private int timesTalked = 0;

    /// <summary>
    /// How many lines in the dialogue are printed.</summary>
    private int count = 0;

    /// <summary>
    /// Story line for item/npc.</summary>
    private string[] storyLines;

    /// <summary>
    /// Character being talked to.</summary>
    string npcCharacter;

    /// <summary>
    /// Is the dialogue due to finish.</summary>
    bool needtoendconvo;

    /// <summary>
    /// Is it an item being talked to.</summary>
    private bool isItem;

    /// <summary>
    /// Dialogue box.</summary>
    public GameObject dBox;

    /// <summary>
    /// Dialogue text field.</summary>
    public Text dText;

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

    /// <summary>
    /// Start conversation with a character.</summary>
    public void StartConvo(string character)
    {
        Debug.Log(character);
        Debug.Log(GameManager.inst.currentState());

        // Set all variables
        npcCharacter = character;
        count = 0;
        isItem = false;
        GameManager.GameState gameState = GameManager.inst.currentState();

        //This is hardcoded for debugging use the line above instead
        //GameManager.GameState gameState = GameManager.GameState.FIND_BERTHA;
        Debug.Log(GameManager.inst.currentState());
        storyLines = characterDialogues[npcCharacter].getStoryLines(gameState);
        dBox.SetActive(true);
    }

    // Displaying appropriate text.
    // Returns true if convo is still going (a line was said)
    // Returns false if convo has ended (so dialogue box has now closed)
    public bool NextLine()
    {
        // End dialogue with spacebar if it's an item
        if (isItem)
        {
            Debug.Log("DialogueManager: Ending dialogue with spacebar");
            EndConvo();
            return false;
        }

        Debug.Log("DialogueManager: The conversation count is: " + count);
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

    /// <summary>
    /// Show the dialogue if it's an item.</summary>
    public void ShowItemDialogue(string line)
    {
        Debug.Log("Showing Item Dialogue");
        dBox.SetActive(true);
        isItem = true;
        dText.text = line;
    }

    /// <summary>
    /// Ends the conversation.</summary>
    public void EndConvo()
    {
        // If it's an item hide the box and reset isItem
        if (isItem)
        {
            dBox.SetActive(false);
            isItem = false;
            return;
        }

        // Change story state if talking to Mi Na after investigating the evidence
        if (GameManager.inst.currentState() == GameManager.GameState.INVESTIGATE_EVIDENCE &&
            npcCharacter.Equals("Mi Na"))
        {
            Debug.Log("DialogueManager: Mi Na story state change");
            GameManager.inst.WorldManager.openCharlesRoom();
        }

        // Reset the dialogue box and NPC character
        Debug.Log("DialogueManager: End of conversation");
        dBox.SetActive(false);
        npcCharacter = null;

        //Switch to the next tutorial or find bertha story state after talking to enough people
        switch (timesTalked)
        {
            case 0:
            {
                GameManager.inst.WorldManager.secondTutorial();
                break;
            }
            case 1:
            {
                GameManager.inst.WorldManager.finalTutorial();
                break;
            }
            case 2:
            {
                GameManager.inst.WorldManager.sampleItem();
                break;
            }
        }
        timesTalked++;
    }
}