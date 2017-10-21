using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.World;
using UnityEngine;

namespace Assets.Scripts
{
	/// <summary>
	/// WorldManager is what manages the world the player interacts with; movement between rooms, where rooms are, 
	/// where to spawn players, suggesting the next state and how warppards work. It's responsibility is store the state
	/// of the world. It only depends on classes in its World directory and GameManager.</summary>
	[Serializable()]
	public class WorldManager : MonoBehaviour
    {
	    /// <summary>
	    /// Determines if the player is allowed to go to enter another room.</summary>
	    public bool canGoTo(RoomLocations.RoomsSpawns room)
	    {
		    // Allows the player to enter the security room if they are in the correct story state
		    if (room == RoomLocations.RoomsSpawns.BasementSecurity)
		    {
			    if (GameManager.inst.currentState() < GameManager.GameState.ENTER_SECURITY)
			    {
				    return false;
			    }
			    else
			    {
				    Debug.Log("WorldManager: Allowing access to the security room through the wine cellar");
				    enteredSecurity();
				    return true;
			    }
		    }
		    return true;
	    }
	    
	    // The below methods are called when an appropriate event happens (that is the method name) and may cause a 
	    // change in the state of game story
	    
		public void startTutorial()
		{
			GameManager.inst.newState (GameManager.GameState.TUTORIAL_1);
		}

		public void secondTutorial()
		{
			GameManager.inst.newState (GameManager.GameState.TUTORIAL_2);
		}

		public void finalTutorial()
		{
			GameManager.inst.newState (GameManager.GameState.TUTORIAL_3);
		}

		public void sampleItem()
		{
			GameManager.inst.newState (GameManager.GameState.FIND_BERTHA);
		}

		public void foundBertha()
		{
			GameManager.inst.newState (GameManager.GameState.GET_SECURITY_KEY);
		}

		public void foundKey()
		{
			GameManager.inst.newState (GameManager.GameState.ENTER_SECURITY);
		}

	    public void enteredSecurity()
	    {
		    GameManager.inst.newState(GameManager.GameState.FIND_SEC_EVIDENCE);
	    }

		public void foundSecurityEvidence()
		{
			GameManager.inst.newState (GameManager.GameState.INVESTIGATE_EVIDENCE);
		}

		public void openCharlesRoom()
		{
			GameManager.inst.newState (GameManager.GameState.GET_TAPES);
		}

		public void foundTapes()
		{
			GameManager.inst.newState (GameManager.GameState.TRY_TAPES);
		}

		public void wallNiche()
		{
			GameManager.inst.newState (GameManager.GameState.POWER_SOURCE);
		}

		public void tryPowerSource()
		{
			GameManager.inst.newState (GameManager.GameState.PLAY_TAPES);
		}

		public void watchTapes()
		{
			GameManager.inst.newState (GameManager.GameState.FINAL_EVIDENCE);
		}

		public void inspectSafe()
		{
			GameManager.inst.newState (GameManager.GameState.ACCUSE);
		}

		public void accuse()
		{
			GameManager.inst.newState (GameManager.GameState.FINISHED);
		}
    }
}
