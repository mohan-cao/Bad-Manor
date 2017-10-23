using System;
using CnControls;
using Fungus;
using UnityEngine;

namespace Assets.Scripts.Characters
{
	/// <summary>
	///     Player class represents the main character which is also the player. It is responsible for everything to do the
	///     player interacting with the world; items, NPCs and collisions. Depends on DialogueManager.
	/// </summary>
	[Serializable]
    internal class Player : Character
    {
	    /// <summary>
	    ///     Time the player moves for.
	    /// </summary>
	    public const float MoveTime = 0.1f;

        //<summary>
        /// Private animator which assists with the animation when the player walks
        private Animator _animator;

	    /// <summary>
	    ///     Responsible for managing dialogue.
	    /// </summary>
	    private DialogueManager _dialogueManager;

	    /// <summary>
	    ///     Whether or not the player is currently engaged in a conversation.
	    /// </summary>
	    private bool _inConversation;

	    /// <summary>
	    ///     Rigid body the player sprite.
	    /// </summary>
	    private Rigidbody2D _rigidBody2D;

        private SoundManager _soundManager;

        public AudioClip _walkingSound;

	    public GameObject _Journal;

        public Flowchart dialogueFlowchart;
        private bool escapePressed = false;
        private SimpleJoystick js;
        public static bool journalopen;

        private bool spacePressed = false;

	    /// <summary>
	    ///     Initialises fields, this method is executed when the player is created in Unity.
	    /// </summary>
	    private void Start()
        {
            _rigidBody2D = GetComponent<Rigidbody2D>();
            _dialogueManager = FindObjectOfType<DialogueManager>();
            _soundManager = FindObjectOfType<SoundManager>();
            _inConversation = false;
            _animator = GetComponent<Animator>();
        }

	    /// <summary>
	    ///     Method is run once per physics frame and updates the position of the player by multiplying the force vectors
	    ///     with move time.
	    /// </summary>
	    private void FixedUpdate()
        {
            var inConversation = dialogueFlowchart.GetBooleanVariable("IN_CONVERSATION");
            if (inConversation)
            {
                //CheckConversation();
                //Configure the animation of the player
                _animator.SetFloat("MoveX", 0f);
                _animator.SetFloat("MoveY", 0f);
            }
            else if (_Journal.gameObject.activeSelf)
            {
                //do nothing
            }
            else
            {
	            if (CnInputManager.GetButtonDown("Esc") || Input.GetKeyUp(KeyCode.Escape))
                {
		            _Journal.GetComponent<Journal>().OpenJournal();
	            }
                // Get X and Y vectors
                var moveHorizontal = Input.GetAxisRaw("Horizontal") + CnInputManager.GetAxisRaw("H");
                var moveVertical = Input.GetAxisRaw("Vertical") + CnInputManager.GetAxisRaw("V");
                // If vectors are non-zero
                if (moveVertical != 0 || moveHorizontal != 0)
                {
                    // then figure out the sum
                    var movement = new Vector3(moveHorizontal, moveVertical, 0f);
                    // multiply by movement time and sum the old position with the change in position
                    transform.Translate(movement * MoveTime);
                    _soundManager.PlaySound(_walkingSound);
                }

                //Configure the animation of the player
                _animator.SetFloat("MoveX", Input.GetAxisRaw("Horizontal") + CnInputManager.GetAxisRaw("H"));
                _animator.SetFloat("MoveY", Input.GetAxisRaw("Vertical") + CnInputManager.GetAxisRaw("V"));
            }
        }

	    /// <summary>
	    ///     If the player has pressed the escape button then the conversation is left. If the player has pressed the
	    ///     space button then the conversation continues.
	    /// </summary>
	    private void CheckConversation()
        {
            if (Input.GetKeyUp(KeyCode.Space) || CnInputManager.GetButtonDown("Space"))
            {
                Debug.Log("Player: Space was pressed; continuing conversation");
                _inConversation = _dialogueManager.NextLine();
            }
            else if (Input.GetKeyUp(KeyCode.Escape) || CnInputManager.GetButtonDown("Esc"))
            {
                Debug.Log("Player: Esc was pressed; leaving conversation");
                _dialogueManager.EndConvo();
                _inConversation = false;
            }
        }


	    /// <summary>
	    ///     Called every frame where another object is within the player's collider. This is used for interacting with
	    ///     the NPCs.
	    /// </summary>
	    private void OnTriggerStay2D(Collider2D other)
        {
            //Debug.Log ("Player: OnTriggerStay2D");
            if (other.gameObject.tag.Equals("NPC"))
            {
                // If the player wants to interact (space button is pressed) and they are not currently in a conversation
                // then a new one is started.
                if ((Input.GetKeyUp(KeyCode.Space) || CnInputManager.GetButtonDown("Space")) && !_inConversation)
                {
                    Debug.Log("Player: Starting conversation with: " + other.gameObject.name);
                    Debug.Log("Player: The current state is: " + GameManager.inst.currentState());
                    _dialogueManager.StartConvo(other.gameObject.name);
                    _inConversation = true;
                }
            }
            else if (other.gameObject.tag.Equals("Collide"))
            {
                Debug.Log("we're in collision!");
            }
        }

	    /// <summary>
	    ///     Called every frame where another object enters the player's collider. This is used for interacting with the
	    ///     items in the world.
	    /// </summary>
	    private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log(other.gameObject.tag);
            if (other.gameObject.tag.Equals("ItemPickUp"))
            {
                // Informs the ItemManageranager that the player has interacted with an item. True is returned if the 
                // interaction leads to dialogue.
                other.gameObject.SetActive(false);
                _inConversation = GameManager.inst.ItemManager.interactedWithItem(other.gameObject);
                Debug.Log("Player: Trigger collider with " + other.gameObject.name
                          + " | Dialogue triggered: " + _inConversation);
            }
        }
    }
}