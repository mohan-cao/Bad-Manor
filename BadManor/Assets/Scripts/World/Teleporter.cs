using UnityEngine;
using System;
using CnControls;
using UnityEngine.UI;

namespace Assets.Scripts.World
{
    /// <summary>
    /// A class representing a warp pad/teleporter.
    /// </summary>
    [Serializable()]
    public class Teleporter : MonoBehaviour
    {
        public int teleporterID;
        public Text guide;
        public int destinationID;
        protected bool inContact = false;
        protected GameObject player;

        /// <summary>
        /// Check for player inside zone
        /// </summary>
        /// <param name="other"></param>
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                inContact = true;
                player = other.gameObject;
                guide.text = "Press [X] to enter.";
            }
        }

        /// <summary>
        /// Check that player is still in zone.
        /// </summary>
        /// <param name="other"></param>
        void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                guide.text = "Press [X] to enter.";
            }
        }

        /// <summary>
        /// Check that player has left zone.
        /// </summary>
        /// <param name="other"></param>
        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                inContact = false;
                guide.text = "";
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (inContact && ( /*Input.GetKeyUp(KeyCode.Space) ||*/
                    Input.GetKeyUp(KeyCode.X) || CnInputManager.GetButtonDown("Space")))
            {
                GameObject[] allTeleporters = GameObject.FindGameObjectsWithTag("Teleporter");
                foreach (GameObject go in allTeleporters)
                {
                    Teleporter tp = go.GetComponent<Teleporter>();
                    if (tp.teleporterID == destinationID)
                    {
                        // move to that one
                        player.transform.position = tp.transform.position;
                        break;
                    }
                }
            }
        }
    }
}