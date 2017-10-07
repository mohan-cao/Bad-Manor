using UnityEngine;
using System;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.World
{
    public class WarpPad : MonoBehaviour
    {

        public int SceneToTeleportTo;
        public float hardCodeX;
        public float hardCodeY;

        // Use this for initialization
        void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                SceneManager.LoadScene(SceneToTeleportTo);
                other.transform.position = new Vector3(hardCodeX, hardCodeY);
            }
        }
    }
}
