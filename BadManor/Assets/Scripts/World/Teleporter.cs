using UnityEngine;
using System;
using UnityEngine.UI;

namespace Assets.Scripts.World
{

    public class Teleporter : MonoBehaviour
    {
        public int teleporterID;
        public Text guide;
        public int destinationID;
        private bool inContact = false;
        GameObject player;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                inContact = true;
                player = other.gameObject;
                guide.text = "Press [X] to enter.";
            }
        }

        void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                guide.text = "Press [X] to enter.";
            }
        }

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
            if (inContact && Input.GetKeyUp(KeyCode.X))
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
    
