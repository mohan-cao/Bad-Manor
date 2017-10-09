using UnityEngine;
using System.Collections;
using Assets.Scripts.UIs;
using UnityEngine.UI;

public class Journal : Interface {

    public Transform journal;
    private bool isShowing = false;
	
    public void Start()
    {
        journal.gameObject.SetActive(false);
    }

	public void toggleJournal()
    {
        Debug.Log("HIDE OR SHOW MOFO " + isShowing);
        journal.gameObject.SetActive(!isShowing);
        isShowing = !isShowing;
    }
}
