using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class Journalizer : MonoBehaviour {

    public void Start()
    {
        
    }

    public void winGame()
    {
        GameManager.inst.correctAnswer();
        SceneManager.LoadScene("EndScreen");
    }

    public void loseGame()
    {
        SceneManager.LoadScene("EndScreen");
    }


}
