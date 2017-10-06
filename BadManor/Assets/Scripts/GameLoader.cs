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
        public static GameLoader inst = null;
        
        private void Awake()
        {
			inst = inst ?? this;
            if (inst != this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
			UnityEngine.SceneManagement.SceneManager.LoadScene ("WelcomeScene");
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
