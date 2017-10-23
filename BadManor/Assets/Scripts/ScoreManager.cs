﻿using System;
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
    }
}
