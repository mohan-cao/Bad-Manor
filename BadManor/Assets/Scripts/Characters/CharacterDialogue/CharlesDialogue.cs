using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Random = UnityEngine.Random;

/// <summary>
/// Character dialogue, is all of the random and story lines plus any conditions required to use them.</summary>
[Serializable()]
public class CharlesDialogue : CharacterDialogue
{
    /// <summary>
    /// Name of the character.</summary>
    private string characterName = "Charles F. Davenport";

    /// <summary>
    /// Story lines the NPC will say in conversation.</summary>
    private Dictionary<GameManager.GameState, string[]> storyLines = new Dictionary<GameManager.GameState, string[]>();

    /// <summary>
    /// Random lines the NPC will say in conversation.</summary>
    private List<string> randomLines = new List<string>();

    /// <summary>
    /// The singleton pattern instance of the character's dialogue to enforce it.</summary>
    private static CharlesDialogue inst;

    /// <summary>
    /// Gets the singleton pattern instance.</summary>
    public static CharlesDialogue getInstance()
    {
        if (inst == null)
            inst = new CharlesDialogue();

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
    private CharlesDialogue()
    {
        storyLines[GameManager.GameState.TUTORIAL_1] = new string[]
        {
            "Hey, what's up",
            "Player",
            "Did you hear that Maurice used to be in love with Bertha? Apparently she rejected him because he was 40 years older than her. It’s a shame they didn’t marry, together they would have been the richest couple in the country!",
            characterName
        };

        storyLines[GameManager.GameState.TUTORIAL_2] = new string[]
        {
            "Hey, what's up",
            "Player",
            "The debt collectors will surely be paying a visit to Sam soon. He’s been bleeding money for months at the blackjack table.",
            characterName
        };

        storyLines[GameManager.GameState.TUTORIAL_3] = new string[]
        {
            "Hey, what's up",
            "Player", "Why would mom leave me off of the will? Maybe Avni’s complaints have gotten to her.",
            characterName
        };

        storyLines[GameManager.GameState.INVESTIGATE_EVIDENCE] = new string[]
        {
            "I found a belt with the initials C.F.D. on it in the security room. Do you know anything about this?",
            "Player", "What are you doing snooping around? You better leave before I get Mi Na to make you leave.",
            characterName
        };


        randomLines.Add("This margarita is delicious, I think I might get another one");
        randomLines.Add(
            "Have you tried Iwo’s Special Coupled Tempura? He doesn’t usually make it except for special occasions like tonight.");
        randomLines.Add(
            "One of Bertha and Maurice’s old movies is going to be playing later tonight, I remember watching it back when it was released.;Maurice looks ancient… how old is he? 90? 100?");
        randomLines.Add("Sam is so handsome, it’s no wonder the ladies are obsessed with him.");
        randomLines.Add("The way Iwo’s sushi is encapsulated in seaweed is so classy.");
        randomLines.Add("I’ve eaten so much of Iwo’s sushi tonight - my stomach is sushi all the way down!");
        randomLines.Add("The security manager is small, but she really intimidates me.");
        randomLines.Add("I think Mr. Bernanke might be counting cards… he never seems to lose at Blackjack.");
        randomLines.Add("Look how lonely Maurice seems. If only he’d gotten over Bertha and found a wife.");
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
        else if ((int) state > 7)
        {
            return new string[]
            {
                "What are you doing snooping around? You better leave before I get Mi Na to make you leave.",
                characterName, "", "Player"
            };
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