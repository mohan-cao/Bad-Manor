using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Characters;
using UnityEngine;

namespace Assets.Scripts
{
	public class CharacterManager : MonoBehaviour
    {

		public float moveTime = 0.1f;		//Time to move character in seconds

		private BoxCollider2D collide;		//Instance of BoxCollider2D attached to this character
		private Rigidbody2D rb2d;			//Instance of RigidBody2D attached to this character

		public virtual void Start()
		{
			//Initialise 'collide' with reference to BoxCollider2D
			collide = GetComponent<BoxCollider2D> ();

			//Initialise 'rb2d' with reference to RigidBody2D
			rb2d = GetComponent<Rigidbody2D> ();
		}

		//public bool Move (int xDir, int yDir, 

    }

}
