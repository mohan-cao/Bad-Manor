using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
	/// <summary>
	/// GameManager is the state of the game; everything from the character positions to the sounds being played. It is
	/// responsible for keeping track of all states by delegating to sub-managers which will in turn hold state and so 
	/// on. It is also responsible for holding the state of the story which implies a lot about all other objet's state.
	/// There is currently a dependency for Character, Item, Sound, Score, UI and World Managers only for the prototype,
	/// this is subject to change as it will probably have greater responsibility later when saving is implemented.
	/// </summary>
	/// <remarks>
	/// This implements a singleton pattern to ensure there is no double up of game state while playing.</remarks>
	[Serializable()]
    public class GameManager : MonoBehaviour
    {
	    /// <summary>
	    /// Instance of the singleton patter.</summary>
	    public static GameManager inst = null;
	    
	    /// <summary>
	    /// Instances of each of the sub-managers.</summary>
        public CharacterManager CharacterManager;
        public ItemManager ItemManager;
        public ScoreManager ScoreManager;
        public SoundManager SoundManager;
        public UIManager UIManager;
        public WorldManager WorldManager;

	    private Boolean _won = false;

	    /// <summary> 
	    /// A dictionary which stores all parameters to do with game state.</summary>
		public Dictionary<string,object> Parameters;
	    /// <summary>
	    /// A dictionary not currently used in prototype as the dialogue system is bound to change.</summary>
		public Dictionary<string,object> DialogueLines;

	    /// <summary>
	    /// The story state of the game which starts on the first tutorial.</summary>
		private GameState _gameState = GameState.TUTORIAL_1;

	    /// <summary>
	    /// GameState is all possible story states.</summary>
        public enum GameState
        {
            INITIAL = 0,
            TUTORIAL_1 = 1,
            TUTORIAL_2 = 2,
            TUTORIAL_3 = 3,
            FIND_BERTHA = 4,
            GET_SECURITY_KEY = 5,
            ENTER_SECURITY = 6,
            FIND_SEC_EVIDENCE = 7,
            INVESTIGATE_EVIDENCE = 8,
            GET_TAPES = 9,
            TRY_TAPES = 10,
            POWER_SOURCE = 11,
            PLAY_TAPES = 12,
            FINAL_EVIDENCE = 13,
            ACCUSE = 14,
            FINISHED = 15
        }

        
	    /// <summary>
	    /// Enforces the singleton pattern by ensuring only the most recent instantiation survives.</summary>
        public GameManager()
        {
            inst = inst ?? this;
            InitGame();
        }

	    /// <summary>
	    /// When a new instance is made the game must be initialised and this method does that. All sub-managers are 
	    /// made, game map loaded, dialogue loaded, dictionaries initialised, score/timer starte, etc.</summary>
        void InitGame()
        {
            CharacterManager = new CharacterManager();
            ItemManager = new ItemManager(this);
            ScoreManager = new ScoreManager();
            SoundManager = new SoundManager();
            UIManager = new UIManager();
            WorldManager = new WorldManager();
			DialogueLines = new Dictionary<string, object> ();
			Parameters = new Dictionary<string, object> ();

			SceneManager.LoadScene ("NewManor");
	        
	        ScoreManager.resume();
            // Start everything here
            // Load to main screen
            // Find save game
            // Pre-load save game
            // Load options picked
            // Get ready to start timing
        }

	    /// <summary>
	    /// Informs the current story state.</summary>
        public GameState currentState()
        {
            return _gameState;
        }

	    /// <summary>
	    /// The next story state can be suggested but it wont be entered unless it's only moving the next consecutive 
	    /// one. Anything that needs to be done on state change can occur here</summary>
        public void newState(GameState nextState)
        {
			if (nextState == _gameState + 1) {
				if (nextState == GameState.TUTORIAL_1) {
					ScoreManager.resume ();
				}
				if (nextState == GameState.FINISHED) {
					ScoreManager.pause ();
				}
				_gameState = nextState;
				Debug.Log("GameManager: State is now: " + nextState);
			}
        }

	    /// <summary>
	    /// Returns the time taken for the player to play the game thus far.</summary>
        public long timeSinceStart()
        {
            return ScoreManager.timeSinceStart();
        }

	    /// <summary>
	    /// A currently useless method to load dialogue as post-prototype the dialogue system will be overhauled.
	    /// </summary>
		private object accessData(JSONObject obj){
			switch(obj.type){
			case JSONObject.Type.OBJECT:
				//Debug.Log ("Nested JSONObject found");
				Dictionary<string,object> dict = new Dictionary<string, object> ();
				for(int i = 0; i < obj.list.Count; i++){
					string key = (string)obj.keys[i];
					JSONObject j = (JSONObject)obj.list[i];
					dict.Add (key, accessData (j));
					//Debug.Log ("key: " + key + ", value: " + accessData (j));
				}
				return dict;
			case JSONObject.Type.ARRAY:
				//Debug.Log ("Array found");
				List<object> list = new List<object> ();
				foreach (JSONObject j in obj.list) {
					list.Add (accessData (j));
					//Debug.Log ("index: "+j+", value: "+accessData (j));
				}
				Debug.Log (list);
				return list;
			case JSONObject.Type.STRING:
				return obj.str;
			case JSONObject.Type.NUMBER:
				return obj.n;
			case JSONObject.Type.BOOL:
				return obj.b;
			case JSONObject.Type.NULL:
				return null;
			}
			return null;
		}

	    public void correctAnswer()
	    {
		    _won = true;
	    }

	    public Boolean won()
	    {
		    return _won;
	    }
    }
}