using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        private CharacterManager characterM;
        private ItemManager itemM;
        private ScoreManager scoreM;
        private SoundManager soundM;
        private UIManager uiM;
        private WorldManager worldM;

        private GameState gameState = 0;

        public enum GameState
        {
            INITIAL = 0,
            TUTORIAL_1 = 1,
            TUTORIAL_2 = 2,
            TUTORIAL_3 = 3,
            FIND_BERTHA = 4,
            GET_SECURITY_KEY = 5,
            ENTER_SECURITY = 6,
            FIND_SEC_EVIDENCE = 7,
            INVESTIGATE_EVIDENCE = 8,
            GET_TAPES = 9,
            TRY_TAPES = 10,
            POWER_SOURCE = 11,
            PLAY_TAPES = 12,
            FINAL_EVIDENCE = 13,
            ACCUSE = 14,
            FINISHED = 15
        }

        public static GameManager inst = null;
        
        public GameManager()
        {
            inst = inst ?? this;
            InitGame();
        }

        void InitGame()
        {
            characterM = new CharacterManager();
            itemM = new ItemManager();
            scoreM = new ScoreManager();
            soundM = new SoundManager();
            uiM = new UIManager();
            worldM = new WorldManager();
            // Start everything here
            // Load to main screen
            // Find save game
            // Pre-load save game
            // Load options picked
            // Get ready to start timing
        }

        public GameState currentState()
        {
            return gameState;
        }

        public void newState(GameState nextState)
        {
            //HOOK IN HERE TO MAKE CALLS
            if (nextState == GameState.TUTORIAL_1)
            {
                scoreM.resume();
            }
            if (nextState == GameState.FINISHED)
            {
                scoreM.pause();
            }
            gameState = nextState;
        }

        public long timeSinceStart()
        {
            return scoreM.timeSinceStart();
        }
    }
}
