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

	    public DialogueManager dMan;

	    public HashSet<GameObject> seen = new HashSet<GameObject>();
	    public HashSet<GameObject> collected = new HashSet<GameObject>();
	    
		public ItemManager(GameManager gm) {
			_gm = gm;
		}

	    public bool interactedWithItem(GameObject gameObject)
	    {
		    dMan = FindObjectOfType<DialogueManager>();
		    seen.Add(gameObject);
		    Debug.Log("TAG OF SHIT THING HERE IS: " + gameObject.name);
		    if (gameObject.name == "Bertha" && GameManager.inst.currentState() == GameManager.GameState.FIND_BERTHA)
		    {
			    Debug.Log("Find Bertha!");
			    dMan.ShowItemDialogue("Oh my God, it’s Bertha - and her body has been shoved down the chimney! Someone murdered her, but who? Her body is still warm - it had to have happened in the last few hours. The murderer must still be at the party… I shouldn’t let anyone else find out about this. If I stay undercover I might be able to solve this case before the murderer realises anyone knows what happened. Maybe if I find my way into the security room I can find out who did this.");
			    GameManager.inst.worldM.foundBertha();
			    return true;
		    }
			else if (gameObject.name == "SecurityKey" && GameManager.inst.currentState() == GameManager.GameState.GET_SECURITY_KEY)
		    {
			    Debug.Log("Find Key!");
			    dMan.ShowItemDialogue("A small metal key.");
			    collected.Add(gameObject);
			    gameObject.SetActive(false);
			    GameManager.inst.worldM.foundKey();
			    return true;
		    }
		    else if (gameObject.name == "Belt" && GameManager.inst.currentState() == GameManager.GameState.FIND_SEC_EVIDENCE)
		    {
			    dMan.ShowItemDialogue("A thick leather belt. The buckle is engraved with the letters C.F.D.");
			    collected.Add(gameObject);
			    gameObject.SetActive(false);
			    GameManager.inst.worldM.foundSecurityEvidence();
			    return true;
		    }
		    else if (gameObject.name == "Monitor" && GameManager.inst.currentState() == GameManager.GameState.TRY_TAPES)
		    {
			    dMan.ShowItemDialogue("There's no power source!");
			    return true;
		    }
		    else if (gameObject.name == "Monitor" && GameManager.inst.currentState() != GameManager.GameState.PLAY_TAPES)
		    {
			    dMan.ShowItemDialogue("There are no tapes in the drive");
			    return true;
		    }
		    else if (gameObject.name == "SecTapes" && GameManager.inst.currentState() == GameManager.GameState.GET_TAPES)
		    {
			    dMan.ShowItemDialogue("A set of security tapes.");
			    collected.Add(gameObject);
			    gameObject.SetActive(false);
			    GameManager.inst.worldM.foundTapes();
			    return true;
		    }
		    else if (gameObject.name == "Niche" && GameManager.inst.currentState() == GameManager.GameState.TRY_TAPES)
		    {
			    dMan.ShowItemDialogue("There’s a niche in the wall where the power source should be. The cord is sticking out of it.");
			    GameManager.inst.worldM.wallNiche();
			    return true;
		    }
		    else if (gameObject.name == "PowerSource" && GameManager.inst.currentState() == GameManager.GameState.POWER_SOURCE)
		    {
			    dMan.ShowItemDialogue("A suitcase sized power source.");
			    collected.Add(gameObject);
			    gameObject.SetActive(false);
			    GameManager.inst.worldM.tryPowerSource();
			    return true;
		    }
		    else if (gameObject.name == "Monitor" && GameManager.inst.currentState() == GameManager.GameState.PLAY_TAPES)
		    {
			    dMan.ShowItemDialogue("The tapes are finally playing. I can see a man - but I can’t make out his face - He’s forcing open the safe in the master bedroom with a sledgehammer!. The next tape shows a man shoving Bertha’s body down the chimney.");
			    GameManager.inst.worldM.watchTapes();
			    return true;
		    }
		    else if (gameObject.name == "chests" && GameManager.inst.currentState() == GameManager.GameState.FINAL_EVIDENCE)
		    {
			    dMan.ShowItemDialogue("The safe is not entirely empty - All the cash has been taken, but Bertha’s personal items, her old movies, an unopened piece of paper, and her jewellry have been left in the safe. The unopened piece of paper is Bertha’s will. It has been tampered with - a new name has been added: Charles Devonport");
			    GameManager.inst.worldM.inspectSafe();
			    return true;
		    }
		    return false;
	    }
    }
}
