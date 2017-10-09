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
		    if (gameObject.name == "Bertha" && GameManager.inst.currentState() == GameManager.GameState.FIND_BERTHA)
		    {
			    GameManager.inst.worldM.foundBertha();
		    }
			else if (gameObject.name == "SecurityKey" && GameManager.inst.currentState() == GameManager.GameState.GET_SECURITY_KEY)
		    {
			    collected.Add(gameObject);
			    gameObject.SetActive(false);
			    GameManager.inst.worldM.foundKey();
		    }
		    else if (gameObject.name == "Belt" && GameManager.inst.currentState() == GameManager.GameState.FIND_SEC_EVIDENCE)
		    {
			    collected.Add(gameObject);
			    gameObject.SetActive(false);
			    GameManager.inst.worldM.foundSecurityEvidence();
		    }
		    else if (gameObject.name == "SecTapes" && GameManager.inst.currentState() == GameManager.GameState.GET_TAPES)
		    {
			    collected.Add(gameObject);
			    gameObject.SetActive(false);
			    GameManager.inst.worldM.foundTapes();
		    }
		    else if (gameObject.name == "PowerSource" && GameManager.inst.currentState() == GameManager.GameState.POWER_SOURCE)
		    {
			    collected.Add(gameObject);
			    gameObject.SetActive(false);
			    GameManager.inst.worldM.tryPowerSource();
		    }
		    else if (gameObject.name == "Monitor" && GameManager.inst.currentState() == GameManager.GameState.PLAY_TAPES)
		    {
			    GameManager.inst.worldM.watchTapes();
		    }
		    else if (gameObject.name == "chests" && GameManager.inst.currentState() == GameManager.GameState.FINAL_EVIDENCE)
		    {
			    GameManager.inst.worldM.inspectSafe();
		    }
	    }
    }
}
