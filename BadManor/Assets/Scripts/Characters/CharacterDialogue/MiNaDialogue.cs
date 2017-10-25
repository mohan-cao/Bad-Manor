using System;
using System.Collections;
using Assets.Scripts;
using System.Collections.Generic;
using Random = UnityEngine.Random;

/// <summary>
/// Character dialogue, is all of the random and story lines plus any conditions required to use them.</summary>
[Serializable()]
public class MiNaDialogue : CharacterDialogue
{
    /// <summary>
    /// Name of the character.</summary>
    private string characterName = "Mi Na Kim";

    /// <summary>
    /// Story lines the NPC will say in conversation.</summary>
    private Dictionary<GameManager.GameState, string[]> storyLines = new Dictionary<GameManager.GameState, string[]>();

    /// <summary>
    /// Random lines the NPC will say in conversation.</summary>
    private List<string> randomLines = new List<string>();

    /// <summary>
    /// The singleton pattern instance of the character's dialogue to enforce it.</summary>
    private static MiNaDialogue inst;

    /// <summary>
    /// Gets the name of the character.</summary>
    public string getName()
    {
        return characterName;
    }

    /// <summary>
    /// Gets the singleton pattern instance.</summary>
    public static MiNaDialogue getInstance()
    {
        if (inst == null)
            inst = new MiNaDialogue();

        return inst;
    }

    /// <summary>
    /// Constructs the instance of the character and in the process loads all the lines and character line.</summary>
    private MiNaDialogue()
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
            "Player",
            "I heard a rumor that Charles has been left off of Bertha’s will. Maybe he is as lazy as Avni says.",
            characterName
        };


        storyLines[GameManager.GameState.FIND_BERTHA] = new string[]
        {
            "Have you seen Bertha lately?",
            "Player", "Of course not, I just asked you to find her. Hurry up and do your job.", characterName
        };

        storyLines[GameManager.GameState.GET_SECURITY_KEY] = new string[]
        {
            "Do you know how I can get into the security room?",
            "Player", "You need a key to get in, Y-you can’t have it. Hurry up and find Bertha.", characterName
        };

        storyLines[GameManager.GameState.INVESTIGATE_EVIDENCE] = new string[]
        {
            "I found a belt with the initials C.F.D. on it in the security room. Do you know anything about this?",
            "Player", "What? You aren’t supposed to go inside there.", characterName,
            "I need the security tapes. Where are they?", "Player", "Th-they're in Charles' room.", characterName,
            "What? Why?", "Player",
            "I-I, U-uh W-we… Okay, look. I’ll tell you, but you have to keep this a secret, alright?", characterName,
            "Just tell me what’s going on.", "Player",
            "Ch-Charles and I are having an affair. I locked the tapes inside his room because it contains all the evidence. I’ll give you the keys to Charles’ room, just leave me alone.",
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
        else if ((int) state > 8)
        {
            return new string[]
            {
                "I Thought I told you to leave me alone.",
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