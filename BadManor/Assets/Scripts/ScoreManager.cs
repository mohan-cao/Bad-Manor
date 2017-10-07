using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Scripts
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField]
        private Stopwatch st;

        public ScoreManager()
        {
            st = new Stopwatch();
        }
        
        public long timeSinceStart()
        {
            return st.ElapsedMilliseconds;
        }

        public void resume()
        {
            st.Start();
        }

        public void pause()
        {
            st.Stop();
        }
    }
}
