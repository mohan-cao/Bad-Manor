using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UIs
{
    /// <summary>
    /// Win/Lose Interface handler. It shows the player's score (time taken) and quits for them when they're ready
    /// .</summary>
    [Serializable()]
    class Score : Interface
    {
        /// <summary>
        /// Text field to change with time.</summary>
        public Text scoretext;
        
        /// <summary>
        /// Take the time taken by the player and place in the text field.</summary>
        private void Start()
        {
            scoretext.text = "Time Taken: " + GameManager.inst.timeSinceStart()/1000 + " seconds";
        }

        /// <summary>
        /// Quits the game for the user.</summary>
        public void Quit()
        {
            Application.Quit();
        }
    }
}
