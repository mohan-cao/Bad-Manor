using UnityEngine;
using Assets.Scripts.UIs;

/// <summary>
/// Journal user interface for recording notes, for prototype only hides/shows and stores the player's notes. Future 
/// plans include showing collected items and pre-wirtten notes.</summary>
public class Journal : Interface {

    /// <summary>
    /// The parent of the whole interface.</summary>
    public Transform journal;
    private bool isShowing = false;
	
    /// <summary>
    /// When GameMap is loaded the Journal interface is hidden.</summary>
    public void Start()
    {
        journal.gameObject.SetActive(false);
    }

    /// <summary>
    /// Show/hide journal from player.</summary>
	public void toggleJournal()
    {
        Debug.Log("Journal: Is showing: " + isShowing);
        journal.gameObject.SetActive(!isShowing);
        isShowing = !isShowing;
    }
}
