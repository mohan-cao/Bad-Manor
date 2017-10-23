using System;

namespace Assets.Scripts
{
    [Serializable()]
    public class SaveGame
    {
        //Item-Flowchart
        public bool IsPluggedIn;
        public bool IsBelt;
        public bool IsMachine;
        //Char-Flowcharts
        public string CURRENT_STATE;
        public int RNG;
        public ScoreManager ScoreManager;
        
        public SaveGame(bool isPluggedIn, bool isBelt, bool isMachine, string currentState, int rng, ScoreManager scoreManager)
        {
            IsPluggedIn = isPluggedIn;
            IsMachine = isMachine;
            IsBelt = isBelt;
            CURRENT_STATE = currentState;
            RNG = rng;
            ScoreManager = scoreManager;
        }
    }
}