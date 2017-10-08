using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;

public class CharlesDialogue : CharacterDialogue
{

    private string characterName = "Charles";
    private Dictionary<GameManager.GameState, string[]> storyLines = new Dictionary<GameManager.GameState, string[]>();
    private List<string> randomLines = new List<string>();



    private static CharlesDialogue inst;

    public static CharlesDialogue getInstance()
    {
        if (inst == null)
            inst = new CharlesDialogue();

        return inst;
    }

    private CharlesDialogue()
    {
        storyLines[GameManager.GameState.TUTORIAL_1] = new string[] { "Hey, what's up",
                    "Player", "Did you hear that Maurice used to be in love with Bertha? Apparently she rejected him because he was 40 years older than her. It’s a shame they didn’t marry, together they would have been the richest couple in the country!"
                    , characterName };

        storyLines[GameManager.GameState.TUTORIAL_2] = new string[] { "Hey, what's up",
                    "Player", "The debt collectors will surely be paying a visit to Sam soon. He’s been bleeding money for months at the blackjack table."
                    , characterName };

        storyLines[GameManager.GameState.TUTORIAL_3] = new string[] { "Hey, what's up",
                    "Player", "Why would mom leave me off of the will? Maybe Avni’s complaints have gotten to her."
                    , characterName };

        storyLines[GameManager.GameState.INVESTIGATE_EVIDENCE] = new string[] { "I found a belt with the initials C.F.D. on it in the security room. Do you know anything about this?",
                    "Player", "What are you doing snooping around? You better leave before I get Mi Na to make you leave."
                    , characterName };




        randomLines.Add("This margarita is delicious, I think I might get another one");
        randomLines.Add("Have you tried Iwo’s Special Coupled Tempura? He doesn’t usually make it except for special occasions like tonight.");
        randomLines.Add("One of Bertha and Maurice’s old movies is going to be playing later tonight, I remember watching it back when it was released.;Maurice looks ancient… how old is he? 90? 100?");
        randomLines.Add("Sam is so handsome, it’s no wonder the ladies are obsessed with him.");
        randomLines.Add("The way Iwo’s sushi is encapsulated in seaweed is so classy.");
        randomLines.Add("I’ve eaten so much of Iwo’s sushi tonight - my stomach is sushi all the way down!");
        randomLines.Add("The security manager is small, but she really intimidates me.");
        randomLines.Add("I think Mr. Bernanke might be counting cards… he never seems to lose at Blackjack.");
        randomLines.Add("Look how lonely Maurice seems. If only he’d gotten over Bertha and found a wife.");
    }

    public string[] getStoryLines(GameManager.GameState state)
    {
        string[] value = null;
        if (storyLines.TryGetValue(state, out value))
        {
            return value;
        }else if ((int)state > 7 )
        {
            return new string[] { "What are you doing snooping around? You better leave before I get Mi Na to make you leave."
                    , characterName, "", "Player" };
        }
        return null;
    }

    public string getRandomLine()
    {
        int index = (int)Random.Range(0f, randomLines.Count - 1);
        return randomLines[index];
    }

}
