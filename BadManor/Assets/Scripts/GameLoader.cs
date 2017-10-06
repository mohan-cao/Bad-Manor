using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameLoader : MonoBehaviour
    {

        public static GameLoader inst;
        public GameObject gM;
    
        private void Awake()
        {
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
