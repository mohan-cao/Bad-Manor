using System;
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
		public ItemManager(GameManager gm) {
			_gm = gm;
		}

		public void InteractedWithItem(Item item){
			if (!item)
				return;
			if (item.name == "") {
				switch (_gm.currentState()) {
				case Assets.Scripts.GameManager.GameState.INITIAL:
					break;
				case Assets.Scripts.GameManager.GameState.FIND_SEC_EVIDENCE:
					_gm.newState (GameManager.GameState.INVESTIGATE_EVIDENCE); // TODO or something like that...
					break;
				}
			}

		}
    }
}
