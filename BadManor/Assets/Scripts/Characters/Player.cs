
using Fungus;
using UnityEngine;

namespace Assets.Scripts.Characters
{
    /// <summary>
    /// Player class represents the main character which is also the player. It is responsible for everything to do the
    /// player interacting with the world; items, NPCs and collisions. Depends on DialogueManager.</summary>
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

        public Flowchart dialogueFlowchart;

        //<summary>
        /// Private animator which assists with the animation when the player walks
        private Animator _animator;

        /// <summary>
        /// Initialises fields, this method is executed when the player is created in Unity.</summary>
        void Start()
        {
            _rigidBody2D = GetComponent<Rigidbody2D>();
            _dialogueManager = FindObjectOfType<DialogueManager>();
            _inConversation = false;
            _animator = GetComponent<Animator>();

        }

        /// <summary>
        /// Method is run once per frame and checks how the player wants to proceed with conversation.</summary>
        private void Update()
        {
            if (_inConversation)
            {
            }
        }

        /// <summary>
        /// Method is run once per physics frame and updates the position of the player by multiplying the force vectors
        /// with move time. </summary>
        void FixedUpdate()
        {
            bool inConversation = dialogueFlowchart.GetBooleanVariable("IN_CONVERSATION");
            if (inConversation)
            {
                //CheckConversation();
            }
            else
            {
                // Get X and Y vectors
                float moveHorizontal = Input.GetAxisRaw("Horizontal");
                float moveVertical = Input.GetAxisRaw("Vertical");
                // If vectors are non-zero
                if (moveVertical != 0 || moveHorizontal != 0)
                {
                    // then figure out the sum
                    Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);
                    // multiply by movement time and sum the old position with the change in position
                    transform.Translate(movement * MoveTime);
                }
                
                //Configure the animation of the player
                _animator.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
                _animator.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
            }
        }

        /// <summary>
        /// If the player has pressed the escape button then the conversation is left. If the player has pressed the 
        /// space button then the conversation continues. </summary>
        


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
                if (Input.GetKeyUp(KeyCode.Space) && !_inConversation)
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
        /// Called every frame where another object enters the player's collider. This is used for interacting with the 
        /// items in the world. </summary>
        void OnTriggerEnter2D(Collider2D other)
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
