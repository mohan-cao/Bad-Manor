using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;

/// <summary>
/// Character dialogue, is all of the random and story lines plus any conditions required to use them.</summary>
public class AnviDialogue : CharacterDialogue
{
    /// <summary>
    /// Name of the character.</summary>
    private string characterName;
    /// <summary>
    /// Story lines the NPC will say in conversation.</summary>
    private Dictionary<GameManager.GameState, string[]> storyLines = new Dictionary<GameManager.GameState, string[]>();
    /// <summary>
    /// Random lines the NPC will say in conversation.</summary>
    private List<string> randomLines = new List<string>();
    /// <summary>
    /// The singleton pattern instance of the character's dialogue to enforce it.</summary>
    private static AnviDialogue inst;

    /// <summary>
    /// Gets the singleton pattern instance.</summary>
    public static AnviDialogue getInstance()
    {
        if (inst == null)
            inst = new AnviDialogue();

        return inst;
    }
    
    /// <summary>
    /// Gets the name of the character.</summary>
    public string getName()
    {
        return characterName;
    }

    /// <summary>
    /// Constructs the instance of the character and in the process loads all the lines and character line.</summary>
    private AnviDialogue()
    {
        characterName = "Anvi Davenport";

        storyLines[GameManager.GameState.TUTORIAL_1] = new string[] { "Hey, what's up?", "Player", "Did you hear that Maurice used to be in love with Bertha? Apparently she rejected him because he was 40 years older than her. It’s a shame they didn’t marry, together they would have been the richest couple in the country!", characterName };
        storyLines[GameManager.GameState.TUTORIAL_2] = new string[] { "Hey, what's up?", "Player", "The debt collectors will surely be paying a visit to Sam soon. He’s been bleeding money for months at the blackjack table.", characterName };
        storyLines[GameManager.GameState.TUTORIAL_3] = new string[] { "Hey, what's up?", "Player", "I heard a rumor that Charles has been left off of Bertha’s will. Maybe my complaints have finally gotten through to her.", characterName };

        randomLines.Add("Do you think Charles will ever get a job? He’s so lazy.");
        randomLines.Add("What’s Charles doing again? Nothing.");
        randomLines.Add("Where’s Charles?");
        randomLines.Add("Sorry, not now. Charles is slacking off again and I need him to get a job.");
    }

    /// <summary>
    /// Returns all story lines the character says.</summary>
    public string[] getStoryLines(GameManager.GameState state)
    {
        string[] value = null;
        if (storyLines.TryGetValue(state, out value))
        {
            return value;
        }
        return null;
    }

    /// <summary>
    /// Returns all random/general lines the character says.</summary>
    public string getRandomLine()
    {
        int index = (int) Random.Range(0f, randomLines.Count - 1);
        return randomLines[index];
    }

}
