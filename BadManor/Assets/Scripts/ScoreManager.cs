using System;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// State of the game score measured in how long it takes to finish the game.</summary>
    [Serializable()]
    public class ScoreManager
    {
        /// <summary>
        /// Store for the name property.</summary>
        [field: NonSerialized]
        public Stopwatch _stopwatch;
        [SerializeField] public long offset; 
        

        [SerializeField] 
        private long _score;

        /// <summary>
        /// Creates a new stopwatch in preparation to keep track of time elapsed.</summary>
        public ScoreManager()
        {
            _stopwatch = new Stopwatch();
            offset = 0;
        }
        
        /// <summary>
        /// Returns how long the player has been playing for.</summary>
        public long timeSinceStart()
        {
            return _stopwatch.ElapsedMilliseconds + offset;
        }

        /// <summary>
        /// Returns elapsed time in seconds.
        /// </summary>
        /// <returns></returns>
        public long time()
        {
            return timeSinceStart() / 1000;
        }
        
        /// <summary>
        /// Continues the timer or starts it if not previously started.</summary>
        public void resume()
        {
            _stopwatch.Start();
        }

        /// <summary>
        /// Stops the timer until it is resumed.</summary>
        public void pause()
        {
            _stopwatch.Stop();
        }

        /// <summary>
        /// Used to be used for adding of score.
        /// </summary>
        /// <param name="score">Amount to be added</param>
        [Obsolete]
        public void addScore(long score)
        {
            _score += score;
        }

        /// <summary>
        /// Used to be used to check current score.
        /// Returns current stored score.
        /// </summary>
        /// <returns></returns>
        [Obsolete]
        public long currentScore()
        {
            return _score;
        }
    }
}
