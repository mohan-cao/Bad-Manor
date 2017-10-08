using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AccusationManager : MonoBehaviour {

    [SerializeField]
    Transform UIPanel;

    public ToggleGroup tg;
    string accusingName;
    void Start()
    {
        UIPanel.gameObject.SetActive(false);
    }

    public void displayAccuse()
    {
        UIPanel.gameObject.SetActive(true);
    }

    public void notNow()
    {
        UIPanel.gameObject.SetActive(false);
    }

    public void makeAccusation()
    {

        // first get active toggle
        foreach(Toggle t in tg.ActiveToggles())
        {
            Debug.Log(t.name);
            accusingName = t.name;
            break;
        }

        if (accusingName == "AccuseSam")
        {
            Debug.Log("you win!");
            notNow();
        } else
        {
            Debug.Log("you lose!");
            notNow();
        }
    }
}
