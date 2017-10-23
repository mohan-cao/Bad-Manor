using System;
using UnityEngine;
using Assets.Scripts;
using Assets.Scripts.UIs;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Accusation is the user interface the player uses for accusing someone of the murders once they have all the 
/// evidence. It's respoonsibility is to keep track of which character is accused, prevent accusations before a minimum
/// amonut of evidence is collected, check if the accusation is correct, show and hide itself. It depends only on 
/// GameManager.</summary>
[Serializable()]
public class Accusation : Interface {

    /// <summary>
    /// The parent of the interface.</summary>
    [SerializeField]
    Transform UIPanel;
    /// <summary>
    /// Accusation options.</summary>
    public ToggleGroup tg;
    /// <summary>
    /// name of currently accused character.</summary>
    string accusingName;
    public Text AccuseBtnText;
    public Button AccuseBtn;
    
    /// <summary>
    /// Run on loading of the GameMap to hide the accusation panel from the player until they're ready.</summary>
    void Start()
    {
        hideAccusePanel();
    }

    /// <summary>
    /// Shows the accusation menu to the player but disables the accuse button until they have sufficient evidence
    /// .</summary>
    public void displayAccuse()
    {
        if (GameManager.inst.currentState() >= GameManager.GameState.ACCUSE)
        {
            AccuseBtnText.text = "ACCUSE!";
            AccuseBtn.enabled = true;
        }
        else
        {
            AccuseBtnText.text = "Need more evidence";
            AccuseBtn.enabled = false;
        }
        Debug.Log("Accusation: Interface displayed");
        UIPanel.gameObject.SetActive(true);
    }

    /// <summary>
    /// Hides the accusation panel.</summary>
    private void hideAccusePanel()
    {
        UIPanel.gameObject.SetActive(false);
    }

    /// <summary>
    /// The player is not ready to accuse anyone so it is hidden again.</summary>
    public void notNow()
    {
        hideAccusePanel();
    }

    /// <summary>
    /// The player has accused a character with enough evidence, if they accusation is correct they win else they lose
    /// .</summary>
    public void makeAccusation()
    {
        if (GameManager.inst.currentState() >= GameManager.GameState.ACCUSE)
        {
            foreach (Toggle t in tg.ActiveToggles())
            {
                Debug.Log(t.name);
                accusingName = t.name;
                break;
            }
            
            if (accusingName == "AccuseSam")
            {
                GameManager.inst.correctAnswer();
                Debug.Log("Accusation: Won");
                hideAccusePanel();
                SceneManager.LoadScene("EndScreen");

            }
            else
            {
                Debug.Log("Accusation: Lost");
                hideAccusePanel();
                SceneManager.LoadScene("EndScreen");
            }
        }
        else
        {
            Debug.Log("Accusation: More evidence required");
        }
    }
}
