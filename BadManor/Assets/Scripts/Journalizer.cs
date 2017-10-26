using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// A Journal helper class
/// </summary>
public class Journalizer : MonoBehaviour
{
    /// <summary>
    /// Unity Start() hook method. Currently unused.
    /// </summary>
    public void Start()
    {
    }

    /// <summary>
    /// Called when game is won.
    /// Loads end screen.
    /// </summary>
    public void winGame()
    {
        GameManager.inst.correctAnswer();
        SceneManager.LoadScene("EndScreen");
    }

    /// <summary>
    /// Called when game is lost.
    /// Loads end screen.
    /// </summary>
    public void loseGame()
    {
        SceneManager.LoadScene("EndScreen");
    }
}