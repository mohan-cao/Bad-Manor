using System;

namespace Assets.Scripts
{
    /// <summary>
    /// Persistable class representing the Game's saved data.
    /// </summary>
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
        
        /// <summary>
        /// SaveGame constructor which saves current game state.
        /// </summary>
        /// <param name="isPluggedIn"></param>
        /// <param name="isBelt"></param>
        /// <param name="isMachine"></param>
        /// <param name="currentState"></param>
        /// <param name="rng"></param>
        /// <param name="scoreManager"></param>
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