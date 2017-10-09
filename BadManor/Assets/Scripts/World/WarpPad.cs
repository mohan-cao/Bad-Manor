using UnityEngine;
using System;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.World
{
    public class WarpPad : MonoBehaviour
    {

        
        public RoomLocations.RoomsSpawns roomToGoTo;

        // Use this for initialization
        void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                if (GameManager.inst.worldM.canGoTo(roomToGoTo))
                {
                    other.transform.position = RoomLocations.getRoomCoords(roomToGoTo);   
                }
            }
        }
    }
}
