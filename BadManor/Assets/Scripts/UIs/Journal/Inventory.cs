using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class representing user inventory.
/// </summary>
public class Inventory : MonoBehaviour
{
    public GameObject[] slots;
    private int itemsCollected = 0;
    private string[] itemNames = new string[] {"Security Key", "Belt", "Key", "Tapes", "Cord", "Will"};

    private string[] itemDescriptions = new string[]
    {
        "A small metal key.",
        "A thick leather belt. The buckle is engraved with the letters C.F.D.",
        "A small metal key.",
        "A set of security tapes.",
        "A power cord.",
        "This is Bertha's will. It has been tampered with! A new name has been added: Charles Devonport."
    };

    public GameObject popUp;

    /// <summary>
    /// Unity hook method on initialization
    /// </summary>
    void Start()
    {
        UpdateDisplay();
    }

    /// <summary>
    /// Called when a new item is collected.
    /// </summary>
    public void NewItemCollected()
    {
        itemsCollected++;
        UpdateDisplay();
    }

    /// <summary>
    /// Updates the display. Hook method.
    /// </summary>
    void UpdateDisplay()
    {
        for (int i = 0; i < itemsCollected; i++)
        {
            GameObject slot = slots[i];
            GameObject itemImage = slot.transform.GetChild(1).gameObject;
            itemImage.SetActive(true);
        }
    }

    /// <summary>
    /// Shows popup of item ID.
    /// </summary>
    /// <param name="itemNum"></param>
    public void showPopUp(int itemNum)
    {
        if (itemNum < itemsCollected)
        {
            foreach (GameObject obj in slots)
            {
                Button btn = obj.GetComponent<Button>();
                btn.interactable = false;
            }
            Text[] texts = popUp.GetComponentsInChildren<Text>();
            texts[0].text = itemNames[itemNum];
            texts[1].text = itemDescriptions[itemNum];
            popUp.SetActive(true);
        }
    }

    /// <summary>
    /// Closes popup of item ID.
    /// </summary>
    public void closePopUp()
    {
        foreach (GameObject obj in slots)
        {
            Button btn = obj.GetComponent<Button>();
            btn.interactable = true;
        }
        popUp.SetActive(false);
    }
}