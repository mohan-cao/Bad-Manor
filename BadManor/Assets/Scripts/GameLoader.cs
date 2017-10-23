using UnityEngine;
using System.IO;  
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assets.Scripts
{
    /// <summary>
    /// GameLoader has to manage creating a new game save or loading an existing one then launching the game. It 
    /// currently only depends on GameManager for prototype but this is assumed to change</summary>
    public class GameLoader : MonoBehaviour
    {
        string filename = Application.persistentDataPath + "savegame";
        
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
            _gameManager = new GameManager();
        }

        /// <summary>
        /// Will load a saved game state but for prototype will create a new one.</summary>
        public void loadGame()
        {
            if (File.Exists(filename))  
            {  
                Stream serialiseStream = File.OpenRead(filename);  
                BinaryFormatter deserializer = new BinaryFormatter();  
                _gameManager = (GameManager)deserializer.Deserialize(serialiseStream);  
                serialiseStream.Close();  
            }
            else
            {
                newGame ();   
            }
        }

        /// <summary>
        /// Only leaves the game for the prototype but should soon save too.</summary>
		public void quitGame()
		{
		    Stream serialiseStream = File.Create(filename);  
		    BinaryFormatter serializer = new BinaryFormatter();  
		    serializer.Serialize(serialiseStream, _gameManager);  
		    serialiseStream.Close(); 
			Application.Quit ();
		}
    }
}
