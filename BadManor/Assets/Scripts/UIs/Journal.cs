using UnityEngine;
using System.Collections;
using Assets.Scripts.UIs;
using UnityEngine.UI;

public class Journal : Interface {

    public GameObject journal;
    private bool isShowing;
    public Button button;
	
    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(toggleJournal);
    }

	void toggleJournal()
    {
      
        journal.SetActive(isShowing);
        isShowing = !isShowing;
    }
}
