using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager inst = null;
        private void Awake()
        {
            inst = inst ?? this;
            if (inst != this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
            InitGame();
        }

        void InitGame()
        {
            // Start everything here
            // Load to main screen
            // Find save game
            // Pre-load save game
            // Load options picked
            // Get ready to start timing
        }
    }
}
