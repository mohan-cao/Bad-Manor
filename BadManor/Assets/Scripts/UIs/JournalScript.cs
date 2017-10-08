using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class JournalScript : MonoBehaviour {

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
