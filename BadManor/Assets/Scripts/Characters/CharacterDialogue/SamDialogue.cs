using UnityEngine;
using System.Collections;
using Assets.Scripts;
using System.Collections.Generic;

public class SamDialogue : CharacterDialogue
{

    private string characterName = "Sam Hyde";
    private Dictionary<GameManager.GameState, string[]> storyLines = new Dictionary<GameManager.GameState, string[]>();
    private List<string> randomLines = new List<string>();

    private static SamDialogue inst;

    public static SamDialogue getInstance()
    {
        if (inst == null)
            inst = new SamDialogue();

        return inst;
    }

    private SamDialogue()
    {
        storyLines[GameManager.GameState.TUTORIAL_1] = new string[] { "Hey, what's up",
                    "Player", "Did you hear that Maurice used to be in love with Bertha? Apparently she rejected him because he was 40 years older than her. It’s a shame they didn’t marry, together they would have been the richest couple in the country!"
                    , characterName };

        storyLines[GameManager.GameState.TUTORIAL_2] = new string[] { "Hey, what's up",
                    "Player", "The debt collectors will surely be paying a visit to Sam soon. He’s been bleeding money for months at the blackjack table."
                    , characterName };

        storyLines[GameManager.GameState.TUTORIAL_3] = new string[] { "Hey, what's up",
                    "Player", "I heard a rumor that Charles has been left off of Bertha’s will. Maybe he is as lazy as Avni says."
                    , characterName };

        randomLines.Add("Damn it! Not again. Why do I always lose?");
        randomLines.Add("I have the worst luck.;It’s so unfair! Everyone gets a good hand but me.");
        randomLines.Add("One of these days I’ll win big, and then I’ll quit gambling for good.");


    }

    public string[] getStoryLines(GameManager.GameState state)
    {
        string[] value = null;
        if (storyLines.TryGetValue(state, out value))
        {
            return value;
        }
        return null;
    }

    public string getRandomLine()
    {
        int index = (int)Random.Range(0f, randomLines.Count - 1);
        return randomLines[index];
    }

}
