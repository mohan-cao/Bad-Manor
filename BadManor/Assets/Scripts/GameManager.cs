using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public CharacterManager characterM;
        public ItemManager itemM;
        public ScoreManager scoreM;
        public SoundManager soundM;
        public UIManager uiM;
        public WorldManager worldM;

		public Dictionary<string,object> parameters;
		public Dictionary<string,object> dialogueLines;

		private GameState gameState = GameState.INITIAL;

		[Serializable]
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

        public static GameManager inst = null;
        
        public GameManager()
        {
            inst = inst ?? this;
            InitGame();
        }

        void InitGame()
        {
            characterM = new CharacterManager();
            itemM = new ItemManager(this);
            scoreM = new ScoreManager();
            soundM = new SoundManager();
            uiM = new UIManager();
            worldM = new WorldManager();
			dialogueLines = new Dictionary<string, object> ();
			parameters = new Dictionary<string, object> ();

			SceneManager.LoadScene (1);
			SceneManager.UnloadScene (0);
			TextAsset[] dialogueLoadedLines = Resources.LoadAll<TextAsset> ("");
			string name = null;
			foreach (TextAsset t in dialogueLoadedLines) {
				JSONObject j = new JSONObject (t.text);
				name = j.GetField ("name").str as String;
				Dictionary<string,object> dictionary = (Dictionary<string,object>)accessData(j);
				dialogueLines.Add (name, dictionary);
			}
            // Start everything here
            // Load to main screen
            // Find save game
            // Pre-load save game
            // Load options picked
            // Get ready to start timing
        }

        public GameState currentState()
        {
            return gameState;
        }

        public void newState(GameState nextState)
        {
			if (nextState == gameState + 1) {
				//HOOK IN HERE TO MAKE CALLS
				if (nextState == GameState.TUTORIAL_1) {
					scoreM.resume ();
				}
				if (nextState == GameState.FINISHED) {
					scoreM.pause ();
				}
				gameState = nextState;
			}
        }

        public long timeSinceStart()
        {
            return scoreM.timeSinceStart();
        }

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
    }
}