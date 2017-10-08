using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameLoader : MonoBehaviour
    {
        private GameManager gM;
        public static GameLoader inst = null;
        
        private void Awake()
        {
			inst = inst ?? this;
            if (inst != this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        public void newGame()
        {
            gM = new GameManager();
        }

        public void loadGame()
        {
			newGame ();
        }

		public void quitGame()
		{
			Application.Quit ();
		}
    }
}
