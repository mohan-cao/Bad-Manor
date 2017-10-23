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

	public GameObject gameMenuPanel;
	public GameObject inventoryPanel;
	public GameObject profilesPanel;
	public GameObject notesPanel;

	private GameObject currentPanel;

	public enum MenuPanel {
		GameMenu,
		Inventory,
		Profiles,
		Notes
	}
	
    /// <summary>
    /// When GameMap is loaded the Journal interface is hidden.</summary>
    public void Start()
    {
        //journal.gameObject.SetActive(false);
		currentPanel = gameMenuPanel;
		SwitchPanel (0);
    }

	public void OpenJournal() {
		journal.gameObject.SetActive(true);
		SwitchPanel (0);
	}

    /// <summary>
    /// Show/hide journal from player.</summary>
	public void CloseJournal()
    {
        journal.gameObject.SetActive(false);
    }

	public void SwitchPanel(int panel) {
		currentPanel.SetActive (false);
		switch (panel) 
		{
			case 0:
				currentPanel = gameMenuPanel;
				break;
			case 1:
				currentPanel = inventoryPanel;
				//Inventory.UpdateItems ();
				break;
			case 2:
				currentPanel = notesPanel;
				break;
			case 3:
				currentPanel = profilesPanel;
				break;
		}
		currentPanel.SetActive (true);
	}

}
