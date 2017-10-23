using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace Assets.Scripts.World
{

    public class UncontrollableTeleporter : Teleporter
    {
       

        // Update is called once per frame
        void Update()
        {
            if (inContact) // there is no checking for key press; instant teleport
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