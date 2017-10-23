using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	public GameObject[] slots;
	public GameObject testItem;
	private HashSet<GameObject> items = new HashSet<GameObject>();

	// Use this for initialization
	void Start () {
		
	}

}
