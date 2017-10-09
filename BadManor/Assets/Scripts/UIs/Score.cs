using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UIs
{
    class Score : Interface
    {
        public Text scoretext;
        
        private void Start()
        {
            scoretext.text = "Time Taken: " + GameManager.inst.timeSinceStart()/1000 + " seconds";
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
