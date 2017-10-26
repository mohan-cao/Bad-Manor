using Assets.Scripts;

/// <summary>
/// What each NPCs dialogue will implement.</summary>
public interface CharacterDialogue
{
    // Use this for initialization
    string[] getStoryLines(GameManager.GameState state);

    // Get the next random line to say
    string getRandomLine();

    //Get the name of the character
    string getName();
}