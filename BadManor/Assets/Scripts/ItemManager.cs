using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Items;
using UnityEngine;

namespace Assets.Scripts
{
    public class ItemManager : MonoBehaviour
    {
		public GameManager _gm;

	    public HashSet<GameObject> seen = new HashSet<GameObject>();
	    public HashSet<GameObject> collected = new HashSet<GameObject>();
	    
		public ItemManager(GameManager gm) {
			_gm = gm;
		}

	    public void interactedWithItem(GameObject gameObject)
	    {
		    seen.Add(gameObject);
		    Debug.Log("TAG OF SHIT THING HERE IS: " + gameObject.name);
		    if (gameObject.name == "Bertha")
		    {
			    GameManager.inst.worldM.foundBertha();
		    }
			else if (gameObject.name == "SecurityKey")
		    {
			    collected.Add(gameObject);
			    gameObject.SetActive(false);
			    GameManager.inst.worldM.foundKey();
		    }
	    }
    }
}
