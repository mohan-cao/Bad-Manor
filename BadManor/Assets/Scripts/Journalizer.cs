using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Journalizer : MonoBehaviour {

    List<string> myNotes = new List<string>();
    List<string> achNames = new List<string>();

    public void addANote(string toAdd)
    {
        Debug.Log("to add");

        myNotes.Add(toAdd);
    }

    public string[] getNotesList()
    {
        Debug.Log("getting list");
        string[] newNotes = new string[myNotes.Count];
        myNotes.CopyTo(newNotes);
        Debug.Log("the note contains:");
        foreach (string e in newNotes)
        {
            Debug.Log(e);
        }
        myNotes.Clear();
        return newNotes;

    }

    public void addAch(string toAdd)
    {
        Debug.Log("to add Achievements");

        achNames.Add(toAdd);
    }

    public string[] getAchList()
    {
        Debug.Log("getting list");
        string[] newAch = new string[achNames.Count];
        achNames.CopyTo(newAch);
        Debug.Log("the note contains:");
        foreach (string e in newAch)
        {
            Debug.Log(e);
        }
        achNames.Clear();
        return newAch;

    }

    public void newItemGet()
    {

    }

    public void winGame()
    {
        SceneManager.LoadScene("EndScreenWin");
    }

    public void loseGame()
    {
        SceneManager.LoadScene("EndScreenLose");
    }


}
