using System;
using System.Collections.Generic;
using Assets.Scripts;
using Random = UnityEngine.Random;

/// <summary>
/// Character dialogue, is all of the random and story lines plus any conditions required to use them.</summary>
[Serializable()]
public class BrangeDialogue : CharacterDialogue
{
    /// <summary>
    /// Name of the character.</summary>
    private string characterName = "Brange A. Davenport";

    /// <summary>
    /// Story lines the NPC will say in conversation.</summary>
    private Dictionary<GameManager.GameState, string[]> storyLines = new Dictionary<GameManager.GameState, string[]>();

    /// <summary>
    /// Random lines the NPC will say in conversation.</summary>
    private List<string> randomLines = new List<string>();

    /// <summary>
    /// The singleton pattern instance of the character's dialogue to enforce it.</summary>
    private static BrangeDialogue inst;

    /// <summary>
    /// Gets the singleton pattern instance.</summary>
    public static BrangeDialogue getInstance()
    {
        if (inst == null)
            inst = new BrangeDialogue();

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
    private BrangeDialogue()
    {
        storyLines[GameManager.GameState.TUTORIAL_1] = new string[]
        {
            "Hey, what's up", "Player", "Bertha looks as " +
                                        "beautiful tonight as she did 30 years ago. How silly was Maurice to think that an old man like him " +
                                        "could have appealed to a beautiful young woman like her, even if he is the richest man in the country.",
            characterName
        };

        storyLines[GameManager.GameState.TUTORIAL_2] = new string[]
        {
            "Hey, what's up", "Player", "The debt " +
                                        "collectors will surely be paying a visit to Sam soon. He’s been bleeding money for months at the " +
                                        "blackjack table.",
            characterName
        };

        storyLines[GameManager.GameState.TUTORIAL_3] = new string[]
        {
            "Hey, what's up", "Player", "Why would Bertha " +
                                        "leave Charles off of the will? Maybe Avni’s complaints have gotten to her.",
            characterName
        };

        storyLines[GameManager.GameState.FIND_BERTHA] = new string[]
        {
            "Have you seen Bertha lately?", "Player",
            "No, I’m so worried. Please find her as soon as you can.", characterName
        };

        storyLines[GameManager.GameState.GET_SECURITY_KEY] = new string[]
        {
            "Do you know how I can get into the " +
            "security room?",
            "Player", "You’ll need a key to get in. Bertha manages everything around here, so I " +
                      "don’t know exactly where it is, but she likes to hide things under the bathmats. Other than that, Mi Na " +
                      "probably has a key.",
            characterName
        };

        /*
         * NEED TO ADD A WAY OF GETTING WHO THE PLAYER IS ACCUSING IN THIS INSTANCE
         */
        storyLines[GameManager.GameState.ACCUSE] = new string[]
        {
            "Please find Bertha.", characterName, "I know " +
                                                  "what happened to Bertha",
            "Player", "What do you mean? Something happened? Is everything alright?",
            characterName, "Bertha was murdered Brange. _____ killed her.", "Player"
        };

        randomLines.Add("Please find Bertha.");
        randomLines.Add("Where is Bertha?");
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