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
            SceneManager.LoadScene(5);

        } else
        {
            Debug.Log("you lose!");
            notNow();
            SceneManager.LoadScene(3);
        }
    }
}
