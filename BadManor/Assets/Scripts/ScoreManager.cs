using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Scripts
{
    class ScoreManager : MonoBehaviour
    {
        [SerializeField]
        private Stopwatch st; //Need to set to 0 on new game
        public long timeSinceStart()
        {
            //to implement
            return st.ElapsedMilliseconds;
        }
    }
}
