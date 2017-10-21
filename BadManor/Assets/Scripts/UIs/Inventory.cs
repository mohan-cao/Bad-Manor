using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	public GameObject[] slots;
	public GameObject testItem;
	private HashSet<GameObject> items = new HashSet<GameObject>();

	// Use this for initialization
	void Start () {
		//items.Add (testItem);
	}
	
//	public void UpdateItems() {
//		int count = 0;
//		foreach (GameObject item in items) {
//			Vector3 pos = slots [count].transform.position;
//			item.transform.position = pos;
//			item.SetActive (true);
//			count++;
//		}
//	}
}
