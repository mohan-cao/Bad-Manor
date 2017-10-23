using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class Achievements : MonoBehaviour {

	public GameObject achievementPane;
	public GameObject viewPort;
	public Sprite[] sprites;

	public readonly string ACH_JOURNAL = "journal";
	public readonly string ACH_TALK = "talk";
	public readonly string ACH_SECURITY = "security";
	public readonly string ACH_IWO = "iwo";
	public readonly string ACH_KEYS = "keys";
	public readonly string ACH_SOLVED = "solved";
	public readonly string ACH_CHIMNEY = "chimney";
	public readonly string ACH_BERTHA = "bertha";
	public readonly string ACH_SOFTWARE_ARCHITECTURE = "sa";
	public readonly string ACH_RED_HERRING = "red";

	private Dictionary<string, string[]> achievementStuff = new Dictionary<string, string[]> ();
	private Dictionary<string, Sprite> achievementBadges = new Dictionary<string, Sprite> ();

	private RectTransform contentPos;

	public void AddAchievement(string name) {
		ScaleContent ();

		GameObject ach = Instantiate (achievementPane);

		Text[] texts = ach.GetComponentsInChildren<Text> ();
		texts [0].text = achievementStuff [name] [0];
		texts [1].text = achievementStuff [name] [1];

		Image badge = ach.GetComponentsInChildren<Image> ()[1];
		badge.sprite = achievementBadges [name];

		ach.transform.SetParent (viewPort.transform);
		ach.SetActive (true);

		RectTransform rt = ach.GetComponent<RectTransform> ();
		rt.localScale = new Vector3 (1, 1, 1);
	}

	void ScaleContent() {
		Transform[] children = new Transform[viewPort.transform.childCount];
		int i = 0;
		foreach (Transform t in viewPort.transform) {
			children [i] = t;
			i++;
		}
		viewPort.transform.DetachChildren ();
		contentPos.sizeDelta = new Vector2 (contentPos.sizeDelta.x, contentPos.sizeDelta.y + 100f);
		foreach (Transform t in children) {
			t.parent = viewPort.transform;
		}
	}

	// Use this for initialization
	void Start () {
		contentPos = viewPort.GetComponent<RectTransform> ();
		contentPos.sizeDelta = new Vector2 (contentPos.sizeDelta.x, 0f);

		achievementStuff[ACH_JOURNAL] = new string[] { "Restricted books allowed", "You have opened the Journal for the first time." };
		achievementStuff[ACH_TALK] = new string[] { "I would like to add you to my professional network", "You have talked to everyone in the manor." };
		achievementStuff[ACH_SECURITY] = new string[] { "Cracking the puzzle interview", "You have solved security room puzzle." };
		achievementStuff[ACH_IWO] = new string[] { "It depends", "You have talked to Iwo Tempo." };
		achievementStuff[ACH_KEYS] = new string[] { "Found private keys", "You have found all the keys." };
		achievementStuff[ACH_SOLVED] = new string[] { "Solved the murder", "You have correctly accused the murderer and solved the case." };
		achievementStuff[ACH_CHIMNEY] = new string[] { "It's getting hot in here", "You have escaped the chimney." };
		achievementStuff[ACH_BERTHA] = new string[] { "She's dead, Brange", "You have found Bertha's lifeless body." };
		achievementStuff[ACH_SOFTWARE_ARCHITECTURE] = new string[] { "Software Architect", "You have read the Software Architecture in Practice 3rd Edition by Bass, Clements and Kazman." };
		achievementStuff[ACH_RED_HERRING] = new string[] { "Red Herring", "You found the test fish. Please ignore." };

		achievementBadges [ACH_JOURNAL] = sprites [0];
		achievementBadges[ACH_TALK] = sprites [1];
		achievementBadges[ACH_SECURITY] = sprites [2];
		achievementBadges[ACH_IWO] = sprites [3];
		achievementBadges[ACH_KEYS] = sprites [4];
		achievementBadges[ACH_SOLVED] = sprites [5];
		achievementBadges[ACH_CHIMNEY] = sprites [6];
		achievementBadges[ACH_BERTHA] = sprites [7];
		achievementBadges[ACH_SOFTWARE_ARCHITECTURE] = sprites [8];
		achievementBadges[ACH_RED_HERRING] = sprites [9];

		AddAchievement (ACH_JOURNAL);
		AddAchievement (ACH_RED_HERRING);
		AddAchievement (ACH_SOFTWARE_ARCHITECTURE);
		AddAchievement (ACH_IWO);
	}
}
