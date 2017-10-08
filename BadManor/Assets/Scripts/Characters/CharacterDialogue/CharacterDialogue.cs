using UnityEngine;
using System.Collections;
using Assets.Scripts;

public interface CharacterDialogue {

    // Use this for initialization
    string[] getStoryLines(GameManager.GameState state);

    string getRandomLine();

}
