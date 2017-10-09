using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	/// <summary>
	/// ItemManager is the state and interaction of all items. It is responsible for keeping track of which items have
	/// been collected and seen. If collected they should be removed from the map and showed in the journal.</summary>
    public class ItemManager : MonoBehaviour
    {
	    /// <summary>
	    /// State of the dialogue.</summary>
	    public DialogueManager dMan;

	    /// <summary>
	    /// State of the game.</summary>
	    private GameManager _gm;
	    private HashSet<GameObject> _seen = new HashSet<GameObject>();
	    private HashSet<GameObject> _collected = new HashSet<GameObject>();
	    
	    /// <summary>
	    /// Sets the game state to refer to.</summary>
		public ItemManager(GameManager gm) {
			_gm = gm;
		}

	    /// <summary>
	    /// When the player interacts with an item dialogue may need to be shown or state changed. All items should be
	    /// seen and they may need to be collected and removed from the map.</summary>
	    public bool interactedWithItem(GameObject gameObject)
	    {
		    dMan = dMan ?? FindObjectOfType<DialogueManager>();
		    _seen.Add(gameObject);
		    Debug.Log("ItemManager: Name of interacted item: " + gameObject.name);
		    
		    if (gameObject.name == "Bertha" && _gm.currentState() == GameManager.GameState.FIND_BERTHA)
		    {
			    Debug.Log("ItemManager: Find Bertha!");
			    dMan.ShowItemDialogue("Oh my God, it’s Bertha - and her body has been shoved down the chimney! " +
					"Someone murdered her, but who? Her body is still warm - it had to have happened in the last few " +
			        "hours. The murderer must still be at the party… I shouldn’t let anyone else find out about this." +
			        " If I stay undercover I might be able to solve this case before the murderer realises anyone " +
			        "knows what happened. Maybe if I find my way into the security room I can find out who did this.");
			    _gm.WorldManager.foundBertha();
			    return true;
		    }
			else if (gameObject.name == "SecurityKey" && _gm.currentState() == GameManager.GameState.GET_SECURITY_KEY)
		    {
			    Debug.Log("ItemManager: Find Key!");
			    dMan.ShowItemDialogue("A small metal key.");
			    _collected.Add(gameObject);
			    gameObject.SetActive(false);
			    _gm.WorldManager.foundKey();
			    return true;
		    }
		    else if (gameObject.name == "Belt" && _gm.currentState() == GameManager.GameState.FIND_SEC_EVIDENCE)
		    {
			    dMan.ShowItemDialogue("A thick leather belt. The buckle is engraved with the letters C.F.D.");
			    _collected.Add(gameObject);
			    gameObject.SetActive(false);
			    _gm.WorldManager.foundSecurityEvidence();
			    return true;
		    }
		    else if (gameObject.name == "Monitor" && _gm.currentState() == GameManager.GameState.TRY_TAPES)
		    {
			    dMan.ShowItemDialogue("There's no power source!");
			    return true;
		    }
		    else if (gameObject.name == "Monitor" && _gm.currentState() != GameManager.GameState.PLAY_TAPES)
		    {
			    dMan.ShowItemDialogue("There are no tapes in the drive");
			    return true;
		    }
		    else if (gameObject.name == "SecTapes" && _gm.currentState() == GameManager.GameState.GET_TAPES)
		    {
			    dMan.ShowItemDialogue("A set of security tapes.");
			    _collected.Add(gameObject);
			    gameObject.SetActive(false);
			    _gm.WorldManager.foundTapes();
			    return true;
		    }
		    else if (gameObject.name == "Niche" && _gm.currentState() == GameManager.GameState.TRY_TAPES)
		    {
			    dMan.ShowItemDialogue("There’s a niche in the wall where the power source should be. The cord is " +
			    	"sticking out of it.");
			    _gm.WorldManager.wallNiche();
			    return true;
		    }
		    else if (gameObject.name == "PowerSource" && _gm.currentState() == GameManager.GameState.POWER_SOURCE)
		    {
			    dMan.ShowItemDialogue("A suitcase sized power source.");
			    _collected.Add(gameObject);
			    gameObject.SetActive(false);
			    _gm.WorldManager.tryPowerSource();
			    return true;
		    }
		    else if (gameObject.name == "Monitor" && _gm.currentState() == GameManager.GameState.PLAY_TAPES)
		    {
			    dMan.ShowItemDialogue("The tapes are finally playing. I can see a man - but I can’t make out his " +
			    	"face - He’s forcing open the safe in the master bedroom with a sledgehammer!. The next tape " +
			        "shows a man shoving Bertha’s body down the chimney.");
			    _gm.WorldManager.watchTapes();
			    return true;
		    }
		    else if (gameObject.name == "chests" && _gm.currentState() == GameManager.GameState.FINAL_EVIDENCE)
		    {
			    dMan.ShowItemDialogue("The safe is not entirely empty - All the cash has been taken, but Bertha’s " +
			    	"personal items, her old movies, an unopened piece of paper, and her jewellry have been left in " +
			        "the safe. The unopened piece of paper is Bertha’s will. It has been tampered with - a new name " +
			        "has been added: Charles Devonport");
			    _gm.WorldManager.inspectSafe();
			    return true;
		    }
		    return false;
	    }
    }
}
