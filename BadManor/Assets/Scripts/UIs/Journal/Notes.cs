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
		ScaleContent ();

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

		AspectRatioFitter aspect;

		RectTransform rt = noteObj.GetComponent<RectTransform> ();
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
		contentPos.sizeDelta = new Vector2 (contentPos.sizeDelta.x, contentPos.sizeDelta.y + NOTE_HEIGHT);
		foreach (Transform t in children) {
			t.parent = viewPort.transform;
		}
	}

	// Use this for initialization
	void Start () {
		contentPos = viewPort.GetComponent<RectTransform> ();
		contentPos.sizeDelta = new Vector2 (contentPos.sizeDelta.x, 0f);
	}
}
