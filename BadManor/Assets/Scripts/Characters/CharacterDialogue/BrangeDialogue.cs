using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;

public class BrangeDialogue : CharacterDialogue
{

    private string characterName = "Brange A. Davenport";
    private Dictionary<GameManager.GameState, string[]> storyLines = new Dictionary<GameManager.GameState, string[]>();
    private List<string> randomLines = new List<string>();

    private static BrangeDialogue inst;

    public static BrangeDialogue getInstance()
    {
        if (inst == null)
            inst = new BrangeDialogue();

        return inst;
    }

    private BrangeDialogue()
    {
        storyLines[GameManager.GameState.TUTORIAL_1] = new string[] { "Hey, what's up", "Player",
            "Bertha looks as beautiful tonight as she did 30 years ago. How silly was Maurice to think that an old man like him could have appealed to a beautiful young woman like her, even if he is the richest man in the country."
                            , characterName };
        storyLines[GameManager.GameState.TUTORIAL_2] = new string[] { "Hey, what's up", "Player",
            "The debt collectors will surely be paying a visit to Sam soon. He’s been bleeding money for months at the blackjack table."
                            , characterName };
        storyLines[GameManager.GameState.TUTORIAL_3] = new string[] { "Hey, what's up", "Player",
            "Why would Bertha leave Charles off of the will? Maybe Avni’s complaints have gotten to her."
                            , characterName };

        storyLines[GameManager.GameState.FIND_BERTHA] = new string[] { "Have you seen Bertha lately?", "Player",
            "No, I’m so worried. Please find her as soon as you can."
                            , characterName };

        storyLines[GameManager.GameState.GET_SECURITY_KEY] = new string[] { "Do you know how I can get into the security room?", "Player",
            "You’ll need a key to get in. Bertha manages everything around here, so I don’t know exactly where it is, but she likes to hide things under the bathmats. Other than that, Mi Na probably has a key."
                            , characterName };

        /*
         * NEED TO ADD A WAY OF GETTING WHO THE PLAYER IS ACCUSING IN THIS INSTANCE
         */
        storyLines[GameManager.GameState.ACCUSE] = new string[] {  "Please find Bertha.", characterName, "I know what happened to Bertha", "Player",
            "What do you mean? Something happened? Is everything alright?", characterName, "Bertha was murdered Brange. _____ killed her.", "Player" };

        randomLines.Add("Please find Bertha.");
        randomLines.Add("Where is Bertha?");
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
