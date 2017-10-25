using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Journal note class for the writing down of notes.
/// </summary>
public class Notes : MonoBehaviour {

	public GameObject evenNote;
	public GameObject oddNote;
	public GameObject viewPort;
    public Journalizer jnr;

	private HashSet<string[]> notes = new HashSet<string[]> ();
	private float NOTE_HEIGHT = 85f;

	private RectTransform contentPos;

	/// <summary>
	/// Adds a note to the notebook.
	/// </summary>
	/// <param name="time"></param>
	/// <param name="note"></param>
	public void AddNote(string time, string note) {
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

	/// <summary>
	/// Scales the content to the correct viewport size.
	/// </summary>
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
        updateNotes();
	}

	/// <summary>
	/// Debug method.
	/// </summary>
    public void updateNotes()
    {
        Debug.Log("adding");
	    //TODO
//        foreach (string str in jnr.getNotesList()) {
//            Debug.Log(str);
//            AddNote("NOTE", str);
//        }
    }
}
