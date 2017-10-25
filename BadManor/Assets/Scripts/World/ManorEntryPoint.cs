using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.World
{
    /// <summary>
    /// ManorEntryPoint moves the player from one room to another, its respoonsibility is teleport the player if the WorldManager
    /// lets it. It had no dependencies other than WorldManager and RoomLocations.</summary>
    [Serializable()]
    public class ManorEntryPoint : MonoBehaviour
    {
        public enum EntryPoints
        {
            GroundToToilet1,
            GroundToToilet2,
            GroundToFirstFloor,
            GroundToBasement,

            BasementToCellar,
            CellarToSecurityRoom,

            FirstToRoom,
            FirstToRoof,

            RoofToChimney,
            ChimneyToRoof,

            Chimney0To1,
            Chimney1To2
        }

        static Vector3[] coords =
        {
            new Vector3(-1.3f, 0f, 0f), new Vector3(1.3f, 0f, 0f),
            new Vector3(31.38f, -19.19f), new Vector3(-1.16f, 27.6f),

            new Vector3(0f, 9.56f), new Vector3(19.14f, -2.48f),
            new Vector3(0f, 10.23f), new Vector3(0f, 11.46f),

            new Vector3(26.16f, -54.75f), new Vector3(83.46f, -161.63f),

            /* TODO CHIMNEY0To1, CHIMNEY1To2 */
        };


        /// <summary>
        /// Room the player wishes to access.</summary>   
        public EntryPoints goTo;

        public Text guide;
        public bool isBackwards = false;
        private bool inContact = false;
        GameObject player;

        /// <summary>
        /// Gets the room coordinates for specified entry points.
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public static Vector3 getRoomCoords(EntryPoints room)
        {
            int enumAsInt = (int) room;
            return coords[enumAsInt];
        }

        /// <summary>
        /// Handles player entering of the warp zone
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
        /// Resets warp zone hint text
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

        /// <summary>
        /// On update, get conditions for warping and check state.
        /// Can force warp players.
        /// </summary>
        void Update()
        {
            if (inContact && goTo.Equals(EntryPoints.RoofToChimney))
            {
                // You fall right into the chimney!
                player.transform.position = player.transform.position + (isBackwards ? -1 : 1) * getRoomCoords(goTo);
            }

            else if (inContact && goTo.Equals(EntryPoints.ChimneyToRoof) && Input.GetKeyUp(KeyCode.X))
            {
                // You automatically climb down the chimney!
                player.transform.position = getRoomCoords(goTo);
            }

            else if (inContact && Input.GetKeyUp(KeyCode.X))
            {
                player.transform.position = player.transform.position + (isBackwards ? -1 : 1) * getRoomCoords(goTo);
            }
        }
    }
}