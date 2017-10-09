using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;

public class MauriceDialogue : CharacterDialogue
{

    private string characterName = "Maurice Copola";
    private Dictionary<GameManager.GameState, string[]> storyLines = new Dictionary<GameManager.GameState, string[]>();
    private List<string> randomLines = new List<string>();
   

    private static MauriceDialogue inst;

    public string getName()
    {
        return characterName;
    }
    
    public static MauriceDialogue getInstance()
    {
        if (inst == null)
            inst = new MauriceDialogue();

        return inst;
    }

    private MauriceDialogue()
    {
        storyLines[GameManager.GameState.TUTORIAL_1] = new string[] { "Hey, what's up",
                    "Player", "Bertha looks as beautiful tonight as she did 30 years ago. How silly was I to think that a rich old man like me could have appealed to a beautiful young woman like her."
                    , characterName };

        storyLines[GameManager.GameState.TUTORIAL_2] = new string[] { "Hey, what's up",
                    "Player", "The debt collectors will surely be paying a visit to Sam soon. He’s been bleeding money for months at the blackjack table."
                    , characterName };

        storyLines[GameManager.GameState.TUTORIAL_3] = new string[] { "Hey, what's up",
                    "Player", "I heard a rumor that Charles has been left off of Bertha’s will. Maybe he is as lazy as Avni says."
                    , characterName };


        storyLines[GameManager.GameState.FIND_BERTHA] = new string[] { "Have you seen Bertha lately?",
                    "Player", "Sorry, I can’t talk right now."
                    , characterName };

        storyLines[GameManager.GameState.POWER_SOURCE] = new string[] { "Ha! I can’t believe Sam is claiming he’s going to be able to pay off all his debts after tonight - he never wins, tonight will be no different.",
                    characterName, "What’s that big thing you’re carrying around?"
                    , "Player"
                    , "Oh, it’s a portable battery pack. I grabbed it from downstairs because I wanted to take some photos of Bertha on the rooftop. My camera is very power hungry, you know."
                    , characterName
                    , "What? Show me the photos."
                    , "Player"
                    , "Of course! Doesn’t Bertha look beautiful in these?"
                    , characterName
                    , "Can I take that battery pack?"
                    , "Player"
                    ,"Absolutely! I don't need it any more."
                    , characterName
                    , "", "Player"};
        randomLines.Add("This margarita is delicious, I think I might get another one");
        randomLines.Add("Have you tried Iwo’s Special Coupled Tempura? He doesn’t usually make it except for special occasions like tonight.");
        randomLines.Add("Don’t know what’s been going on between Avni and Charles… she’s been glaring at him all night.");
        randomLines.Add("Don’t you think Brange looks a little more nervous than usual? He seems pale.");
        randomLines.Add("Bertha must be extremely wealthy to be able to afford this place… It’s gigantic!");
        randomLines.Add("Sam is so handsome, it’s no wonder the ladies are obsessed with him.");
        randomLines.Add("The way Iwo’s sushi is encapsulated in seaweed is so classy.");
        randomLines.Add("I’ve eaten so much of Iwo’s sushi tonight - my stomach is sushi all the way down!");
        randomLines.Add("The security manager is small, but she really intimidates me.");
        randomLines.Add("I think Mr. Bernanke might be counting cards… he never seems to lose at Blackjack.");


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
