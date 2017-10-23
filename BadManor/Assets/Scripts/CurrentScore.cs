using UnityEngine;
using System.Collections;

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

	// Use this for initialization
	public void Start () {
        score = 0;
	}
	
	public void addScore(int score)
    {
        this.score += score;
    }
}
