using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Fungus;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    /// <summary>
    /// GameLoader has to manage creating a new game save or loading an existing one then launching the game. It 
    /// currently only depends on GameManager for prototype but this is assumed to change</summary>
    public class GameLoader : MonoBehaviour
    {
        string filename = "savegame";
        
        /// <summary>
        /// Singleton pattern instance to ensure there's only one GameLoader and state on the same PC.</summary>
        public static GameLoader Inst = null;
        /// <summary>
        /// State of the game.</summary>
        private GameManager _gameManager = null;
        
        /// <summary>
        /// Enforces the singletone pattern, everytime an additional GameLoader is made it is destroyed to ensure there
        /// is only one at any given time to avoid destroying an existing game state.</summary>
        private void Awake()
        {
			Inst = Inst ?? this;
            if (Inst != this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        /// <summary>
        /// Creates a new game state.</summary>
        public void newGame()
        {
            _gameManager = gameObject.AddComponent<GameManager>();
        }

        /// <summary>
        /// Will load a saved game state but for prototype will create a new one.</summary>
        public void loadGame()
        {
            newGame();
            if (File.Exists(filename))
            {
                Debug.LogWarning("TAKE ON UNITY");
                Stream serialiseStream = File.OpenRead(filename);
                Debug.LogWarning("TAKE ON UNITY");
                BinaryFormatter deserializer = new BinaryFormatter();
                Debug.LogWarning("TAKE ON UNITY");
                SaveGame saveGame = deserializer.Deserialize(serialiseStream) as SaveGame;
                Debug.LogWarning("TAKE ON UNITY");
                serialiseStream.Close();
                _gameManager.InitGameFromSave(saveGame);
            }
            else
            {
                newGame();   
            }
        }

        /// <summary>
        /// Only leaves the game for the prototype but should soon save too.</summary>
		public void quitGame()
        {
            saveGame();
            Application.Quit ();
        }

        public void saveGame()
        {
            _gameManager.ScoreManager.pause();
            _gameManager.ScoreManager.offset += _gameManager.ScoreManager.timeSinceStart();
            SaveGame saveGame;
            Flowchart characFlowchart = GameObject.Find("/Char-Flowcharts").GetComponent<Flowchart>();
            Flowchart itemFlowchart = GameObject.Find("/Item-Flowchart").GetComponent<Flowchart>();
            saveGame = new SaveGame(itemFlowchart.GetBooleanVariable("IsPluggedIn"),
                itemFlowchart.GetBooleanVariable("IsBelt"),
                itemFlowchart.GetBooleanVariable("IsMachine"),
                characFlowchart.GetStringVariable("CURRENT_STATE"),
                characFlowchart.GetIntegerVariable("RNG"),
                _gameManager.ScoreManager);
            Stream serialiseStream = File.Create(filename);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(serialiseStream, saveGame);
            serialiseStream.Close();
        }
    }
}
