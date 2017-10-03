using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        private CharacterManager cm;
        private ItemManager im;
        private ScoreManager scorem;
        private SoundManager soundm;
        private UIManager uim;
        private WorldManager wm;

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
            cm = new CharacterManager();
            im = new ItemManager();
            scorem = new ScoreManager();
            soundm = new SoundManager();
            uim = new UIManager();
            wm = new WorldManager();
            // Start everything here
            // Load to main screen
            // Find save game
            // Pre-load save game
            // Load options picked
            // Get ready to start timing
        }

        public long timeSinceStart()
        {
            return sm.timeSinceStart();
        }
    }
}
