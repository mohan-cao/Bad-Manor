using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Journalizer : MonoBehaviour {

   

    public void winGame()
    {
        SceneManager.LoadScene("EndScreenWin");
    }

    public void loseGame()
    {
        SceneManager.LoadScene("EndScreenLose");
    }


}
