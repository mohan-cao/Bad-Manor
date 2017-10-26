using System;
using System.Collections.Generic;
using Assets.Scripts;
using Random = UnityEngine.Random;

/// <summary>
/// Character dialogue, is all of the random and story lines plus any conditions required to use them.</summary>
[Serializable()]
public class SamDialogue : CharacterDialogue
{
    /// <summary>
    /// Name of the character.</summary>
    private string characterName = "Sam Hyde";

    /// <summary>
    /// Story lines the NPC will say in conversation.</summary>
    private Dictionary<GameManager.GameState, string[]> storyLines = new Dictionary<GameManager.GameState, string[]>();

    /// <summary>
    /// Random lines the NPC will say in conversation.</summary>
    private List<string> randomLines = new List<string>();

    /// <summary>
    /// The singleton pattern instance of the character's dialogue to enforce it.</summary>
    private static SamDialogue inst;

    /// <summary>
    /// Gets the name of the character.</summary>
    public string getName()
    {
        return characterName;
    }

    /// <summary>
    /// Gets the singleton pattern instance.</summary>
    public static SamDialogue getInstance()
    {
        if (inst == null)
            inst = new SamDialogue();

        return inst;
    }

    /// <summary>
    /// Constructs the instance of the character and in the process loads all the lines and character line.</summary>
    private SamDialogue()
    {
        storyLines[GameManager.GameState.TUTORIAL_1] = new string[]
        {
            "Hey, what's up?",
            "Player",
            "Did you hear that Maurice used to be in love with Bertha? Apparently she rejected him because he was 40 years older than her. It’s a shame they didn’t marry, together they would have been the richest couple in the country!",
            characterName
        };

        storyLines[GameManager.GameState.TUTORIAL_2] = new string[]
        {
            "Hey, what's up?",
            "Player",
            "The debt collectors will surely be paying a visit to me soon. I've been bleeding money for months at the blackjack table.",
            characterName
        };

        storyLines[GameManager.GameState.TUTORIAL_3] = new string[]
        {
            "Hey, what's up?",
            "Player",
            "I heard a rumor that Charles has been left off of Bertha’s will. Maybe he is as lazy as Avni says.",
            characterName
        };

        randomLines.Add("Damn it! Not again. Why do I always lose?");
        randomLines.Add("I have the worst luck.;It’s so unfair! Everyone gets a good hand but me.");
        randomLines.Add("One of these days I’ll win big, and then I’ll quit gambling for good.");
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