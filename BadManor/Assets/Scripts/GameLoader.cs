using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameLoader : MonoBehaviour
    {
        private GameManager gM;
        public static GameObject inst = null;
        
        private void Awake()
        {
            inst = inst ?? this;
            if (inst != this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
            newGame();
        }

        private void newGame()
        {
            gM = new GameManager();
        }

        private void loadGame()
        {
            //TODO
        }
    }
}
