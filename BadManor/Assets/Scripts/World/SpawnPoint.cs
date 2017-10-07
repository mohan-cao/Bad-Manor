using UnityEngine;
using System.Collections;
using System;

namespace Assets.Scripts.World
{
    public class SpawnPoint : MonoBehaviour
    {

        public String SpawnPointID;

        public Vector3 getLocation()
        {
            return this.transform.position;
        }
        
    }
}
