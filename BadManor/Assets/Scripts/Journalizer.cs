using UnityEngine;
using System.Collections.Generic;

public class Journalizer : MonoBehaviour {

    public GameObject notesPanel;
    public Notes notes;

    List<string> myNotes = new List<string>();

    public void Start()
    {
        notes = notesPanel.GetComponent<Notes>();
    }

    public void addANote(string toAdd)
    {
        Debug.Log("to add");

        myNotes.Add(toAdd);
    }

    public string[] getList()
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
}
