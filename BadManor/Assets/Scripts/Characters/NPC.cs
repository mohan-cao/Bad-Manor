using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Characters
{
	/// <summary>
	/// Not implemented for prototype.</summary>
	/// 
	/// Source - youtube - gamesplusjames - Unity RPG Tutorial 26 & 27
	/// Have an empty walk area with an empty box collider & is trigger
	/// NPC - Have a box collider and is trigger
	/// Rigid Body - Freeze Rotation Z
	/// NPC Script - Walkzone - empty walk area component.
	/// 
	class NPC : Character
	{

		public float moveSpeed;
		private Rigidbody2D myRigidbody;
		public bool isWalking;
		public float walkTime;
		public float waitTime;
		private float walkCounter;
		private float waitCounter;
		private int walkDirection;
		public Collider2D walkzone; 

		/// <summary>
		/// Bottom left and top right corners of the walking area
		/// </summary>
		private Vector2 minwalkpoint;
		private Vector2 maxwalkpoint;




		void Start(){
			myRigidbody = GetComponent<Rigidbody2D> ();
			waitCounter = waitTime;	
			walkCounter = walkTime; 
			chooseDirection ();
			minwalkpoint = walkzone.bounds.min;
			maxwalkpoint = walkzone.bounds.max;

		}

		void Update(){
			if (isWalking) {

				walkCounter = walkCounter - Time.deltaTime;
				if (walkCounter < 0) {
					isWalking = false;
					waitCounter = waitTime;


				}

				switch (walkDirection) {
				case 0:
					myRigidbody.velocity = new Vector2 (0, moveSpeed);
					if (transform.position.y > maxwalkpoint.y) {
						isWalking = false;
						waitCounter = waitTime;

					}

					break;
				case 1:
					myRigidbody.velocity = new Vector2 (moveSpeed,0);


					if (transform.position.x > maxwalkpoint.x) {
						isWalking = false;
						waitCounter = waitTime;

					}

					break;
				case 2:
					myRigidbody.velocity = new Vector2 (0, -moveSpeed);

					if (transform.position.y < minwalkpoint.y) {
						isWalking = false;
						waitCounter = waitTime;

					}

					break;
				case 3:
					myRigidbody.velocity = new Vector2 (-moveSpeed,0 );

					if (transform.position.x < minwalkpoint.x) {
						isWalking = false;
						waitCounter = waitTime;

					}

					break;
				}

				if (walkCounter < 0) {
					isWalking = false;
					waitCounter = waitTime;


				}

			} else {
				waitCounter = waitCounter - Time.deltaTime;
				myRigidbody.velocity = Vector2.zero;

				if (waitCounter < 0) {
					chooseDirection ();

				}
			}


		}



		public void chooseDirection(){
			walkDirection = Random.Range(0, 4);
			isWalking = true;
			walkCounter = walkTime;
		}
	}
}
