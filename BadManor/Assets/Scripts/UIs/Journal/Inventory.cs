using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	public GameObject[] slots;
	private int itemsCollected = 0;
	private string[] itemNames = new string[] { "Security Key", "Belt", "Key", "Tapes", "Cord", "Will" };
	private string[] itemDescriptions = new string[] {
		"A small metal key.",
		"A thick leather belt. The buckle is engraved with the letters C.F.D.",
		"A small metal key.",
		"A set of security tapes.",
		"A power cord.",
		"This is Bertha's will. It has been tampered with! A new name has been added: Charles Devonport." };

	public GameObject popUp;

	void Start() {
		UpdateDisplay ();
	}

	public void NewItemCollected() {
		itemsCollected++;
		UpdateDisplay ();
	}

	void UpdateDisplay() {
		for (int i = 0; i < itemsCollected; i++) {
			GameObject slot = slots [i];
			GameObject itemImage = slot.transform.GetChild (1).gameObject;
			itemImage.SetActive (true);
		}
	}

	public void showPopUp(int itemNum) {
		if (itemNum < itemsCollected) {
			foreach (GameObject obj in slots) {
				Button btn = obj.GetComponent<Button> ();
				btn.interactable = false;
			}
			Text[] texts = popUp.GetComponentsInChildren<Text> ();
			texts [0].text = itemNames [itemNum];
			texts [1].text = itemDescriptions [itemNum];
			popUp.SetActive (true);
		}
	}

	public void closePopUp() {
		foreach (GameObject obj in slots) {
			Button btn = obj.GetComponent<Button> ();
			btn.interactable = true;
		}
		popUp.SetActive (false);
	}

}
