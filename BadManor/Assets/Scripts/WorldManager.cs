using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.World;
using UnityEngine;

namespace Assets.Scripts
{
    public class WorldManager : MonoBehaviour
    {
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
