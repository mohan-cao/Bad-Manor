using UnityEngine;
using System.Collections;
/// <summary>
/// A class used for representing the current score.
/// </summary>
public class CurrentScore : MonoBehaviour {

    public int score;
    public static CurrentScore inst;

    public CurrentScore()
    {
        if (inst == null)
        {
            inst = this;
        }
    }

	/// <summary>
	/// Used to initialize the class variables.
	/// </summary>
	public void Start () {
        score = 0;
	}
	
    /// <summary>
    /// Add score to the existing current score instance.
    /// </summary>
    /// <param name="score"></param>
	public void addScore(int score)
    {
        this.score += score;
    }
}
