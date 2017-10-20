using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Assets.Scripts.World
{
    /// <summary>
    /// Subclass of Teleporter that serves as a spawn point rather than
    /// a teleporter.
    /// TODO: Make Teleporter a Derived Class of this.
    /// </summary>
    public class ArrivalTeleporter : Teleporter
    {

        void OnTriggerEnter2D(Collider2D other)
        {
            //do nothing
        }

        void OnTriggerStay2D(Collider2D other)
        {
            //do nothing
        }

        void OnTriggerExit2D(Collider2D other)
        {
            //do nothing
        }

        // Update is called once per frame
        void Update()
        {
            //do nothing
        }
    }
}