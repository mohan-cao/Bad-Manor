using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Characters
{
    class Player : Character
    {

		public float moveTime = 0.1f;

		private Rigidbody2D rb2d;
		private BoxCollider2D collider;

		void Start()
		{
			rb2d = GetComponent<Rigidbody2D> ();
			collider = GetComponent<BoxCollider2D> ();
		}

		void Update()
		{
			float moveHorizontal = Input.GetAxisRaw ("Horizontal");
			float moveVertical = Input.GetAxisRaw ("Vertical");

			if (moveVertical != 0 || moveHorizontal != 0) 
			{
				Vector3 start = transform.position;
				Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0f);
				Vector3 end = start + (movement * moveTime);

				//collider.enabled = false;
				//RaycastHit2D hit = Physics2D.Linecast (new Vector2(start.x, start.y), new Vector2(end.x, end.y));
				//collider.enabled = true;

				//if (hit.transform == null) 
				//{
					transform.Translate (movement * moveTime);
				//}

			}
		}

    }
}
