using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class Notes : MonoBehaviour {

	public GameObject evenNote;
	public GameObject oddNote;
	public GameObject viewPort;

	private HashSet<string[]> notes = new HashSet<string[]> ();
	private float NOTE_HEIGHT = 85f;

	private RectTransform contentPos;

	public void AddNote(TimeSpan time, string note) {
		notes.Add (new string[] { time.ToString (), note });
		//contentPos.sizeDelta = new Vector2 (contentPos.sizeDelta.x, contentPos.sizeDelta.y + NOTE_HEIGHT);
		foreach (RectTransform rec in viewPort.GetComponentsInChildren<RectTransform>()) {
			//rec.sizeDelta = new Vector2 (rec.sizeDelta.x, rec.sizeDelta.y - NOTE_HEIGHT);
		}
		//ScaleContent ();

		GameObject noteObj;
		if (notes.Count % 2 == 0) {
			noteObj = Instantiate (evenNote);
		} else {
			noteObj = Instantiate (oddNote);
		}

		Text[] texts = noteObj.GetComponentsInChildren<Text> ();
		texts [0].text = time.ToString ();
		texts [1].text = note;

		noteObj.transform.SetParent (viewPort.transform);
		noteObj.SetActive (true);

	
		noteObj.transform.position = new Vector3(292.5f, 313.5f - ((notes.Count - 1) * 85f)	, 0f);



	}

	void ScaleContent() {
		Transform[] children = new Transform[viewPort.transform.childCount];
		int i = 0;
		foreach (Transform t in viewPort.transform) {
			children [i] = t;
			i++;
		}
		viewPort.transform.DetachChildren ();
		contentPos.sizeDelta = new Vector2 (contentPos.sizeDelta.x, contentPos.sizeDelta.y + NOTE_HEIGHT);
		foreach (Transform t in children) {
			t.parent = viewPort.transform;
		}
	}

	// Use this for initialization
	void Start () {
		contentPos = viewPort.GetComponent<RectTransform> ();
		//contentPos.sizeDelta = new Vector2 (contentPos.sizeDelta.x, 0f);

		AddNote (new TimeSpan (19, 20, 35), "This is my test note!");
		AddNote (new TimeSpan (20, 03, 47), "Note two, note two, this is fucking note two!");
		AddNote (new TimeSpan (20, 50, 12), "More notes");
		AddNote (new TimeSpan (21, 30, 00), "This is be the latest one");

	}
}
