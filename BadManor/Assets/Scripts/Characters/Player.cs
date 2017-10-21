using System;
using UnityEngine;
using CnControls;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Characters
{
	/// <summary>
	/// Player class represents the main character which is also the player. It is responsible for everything to do the
	/// player interacting with the world; items, NPCs and collisions. Depends on DialogueManager.</summary>
	[Serializable()]
	class Player : Character
    {
	    /// <summary>
	    /// Time the player moves for.</summary>
		public const float MoveTime = 0.1f;

	    /// <summary>
	    /// Rigid body the player sprite.</summary>
		private Rigidbody2D _rigidBody2D;
	    /// <summary>
	    /// Responsible for managing dialogue.</summary>
		private DialogueManager _dialogueManager;
	    /// <summary>
	    /// Whether or not the player is currently engaged in a conversation.</summary>
		private bool _inConversation;

	    private bool spacePressed = false;
	    private bool escapePressed = false;

	    private SimpleJoystick js;
	    
	    /// <summary>
	    /// Initialises fields, this method is executed when the player is created in Unity.</summary>
		void Start()
		{
			_rigidBody2D = GetComponent<Rigidbody2D> ();
			_dialogueManager = FindObjectOfType<DialogueManager> ();
			_inConversation = false;
		}

	    /// <summary>
	    /// Method is run once per frame and checks how the player wants to proceed with conversation.</summary>
	    private void Update()
	    {
		    if (_inConversation) 
		    {
			    CheckConversation();
		    }
	    }

	    /// <summary>
	    /// Method is run once per physics frame and updates the position of the player by multiplying the force vectors
	    /// with move time. </summary>
	    void FixedUpdate()
		{
			if (_inConversation)
			{
				//CheckConversation();
			}
			else
			{
				// Get X and Y vectors
				float moveHorizontal = Input.GetAxisRaw("Horizontal") + CnInputManager.GetAxis("H");
				float moveVertical = Input.GetAxisRaw("Vertical") + CnInputManager.GetAxis("V");
				// If vectors are non-zero
				if (moveVertical != 0 || moveHorizontal != 0)
				{
					// then figure out the sum
					Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);
					// multiply by movement time and sum the old position with the change in position
					transform.Translate(movement * MoveTime);
				}
			}
		}

	    public void movearound(float v, float h)
	    {
		    if (v != 0 || h != 0)
		    {
			    // then figure out the sum
			    Vector3 movement = new Vector3(h, v, 0f);
			    // multiply by movement time and sum the old position with the change in position
			    transform.Translate(movement * MoveTime);
		    }
	    }

	    /// <summary>
	    /// If the player has pressed the escape button then the conversation is left. If the player has pressed the 
	    /// space button then the conversation continues. </summary>
	    private void CheckConversation()
	    {
		    if (Input.GetKeyUp(KeyCode.Space) || CnInputManager.GetButtonDown("Space")) 
		    {
			    Debug.Log ("Player: Space was pressed; continuing conversation");
			    _inConversation = _dialogueManager.NextLine ();
		    } 
		    else if (Input.GetKeyUp(KeyCode.Escape) || CnInputManager.GetButtonDown("Esc"))
		    {
			    Debug.Log("Player: Esc was pressed; leaving conversation");
			    _dialogueManager.EndConvo();
			    _inConversation = false;
		    }
	    }

	    
	    /// <summary>
	    /// Called every frame where another object is within the player's collider. This is used for interacting with 
	    /// the NPCs. </summary>
		void OnTriggerStay2D(Collider2D other)
		{
			//Debug.Log ("Player: OnTriggerStay2D");
			if (other.gameObject.tag.Equals("NPC")) 
			{
				// If the player wants to interact (space button is pressed) and they are not currently in a conversation
				// then a new one is started.
				if ((Input.GetKeyUp (KeyCode.Space) || CnInputManager.GetButtonDown("Space"))&& !_inConversation) 
				{
					Debug.Log ("Player: Starting conversation with: " + other.gameObject.name);
					Debug.Log("Player: The current state is: " + GameManager.inst.currentState());
					_dialogueManager.StartConvo(other.gameObject.name);
					_inConversation = true;
				}
			} else if (other.gameObject.tag.Equals("Collide"))
            {
                Debug.Log("we're in collision!");
            }
		}

	    /// <summary>
	    /// Called every frame where another object enters the player's collider. This is used for interacting with the 
	    /// items in the world. </summary>
		void OnTriggerEnter2D(Collider2D other)
		{
			Debug.Log(other.gameObject.tag);
			if (other.gameObject.tag.Equals("ItemPickUp"))
			{
				// Informs the ItemManageranager that the player has interacted with an item. True is returned if the 
				// interaction leads to dialogue.
				_inConversation = GameManager.inst.ItemManager.interactedWithItem(other.gameObject);
				Debug.Log("Player: Trigger collider with " + other.gameObject.name
				          + " | Dialogue triggered: " + _inConversation);
			}
		}
    }
}
