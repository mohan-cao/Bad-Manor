using UnityEngine;
using System.Collections;
using Assets.Scripts.UIs;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Accusation : Interface {

    [SerializeField]
    Transform UIPanel;

    public ToggleGroup tg;
    string accusingName;
    

    void Start()
    {
        hideAccusePanel();
    }

    public void displayAccuse()
    {
        Debug.Log("ACCUSE HIM");
        UIPanel.gameObject.SetActive(true);
    }

    private void hideAccusePanel()
    {
        UIPanel.gameObject.SetActive(false);
    }

    public void notNow()
    {
        hideAccusePanel();
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
            hideAccusePanel();
            SceneManager.LoadScene("EndScreenWin");

        } 
        else
        {
            Debug.Log("you lose!");
            hideAccusePanel();
            SceneManager.LoadScene("EndScreenLose");
        }
    }
}
