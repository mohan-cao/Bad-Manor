using UnityEngine;
using System.Collections;
using System;

namespace Assets.Scripts.World
{
    /// <summary>
    /// SpawnPoint represents where the player can be placed on the map.</summary>
    public class SpawnPoint : MonoBehaviour
    {

        public String SpawnPointID;

        /// <summary>
        /// returns the location on the map.</summary>
        public Vector3 getLocation()
        {
            return this.transform.position;
        }
        
    }
}
