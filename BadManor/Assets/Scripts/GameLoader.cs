using System;
using UnityEngine;
using System.IO;  
using System.Collections;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using Fungus;
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
            _gameManager = gameObject.AddComponent<GameManager>() as GameManager;
        }

        /// <summary>
        /// Will load a saved game state but for prototype will create a new one.</summary>
        public void loadGame()
        {
            newGame();
            if (File.Exists(filename))
            {
                UnityEngine.Debug.LogWarning("TAKE ON UNITY");
                Stream serialiseStream = File.OpenRead(filename);
                UnityEngine.Debug.LogWarning("TAKE ON UNITY");
                BinaryFormatter deserializer = new BinaryFormatter();
                UnityEngine.Debug.LogWarning("TAKE ON UNITY");
                SaveGame saveGame = (SaveGame)deserializer.Deserialize(serialiseStream);
                UnityEngine.Debug.LogWarning("TAKE ON UNITY");
                serialiseStream.Close();
                UnityEngine.Debug.LogWarning("TAKE ON UNITY");
                Scene currentScene = SceneManager.GetActiveScene();
                GameObject[] rootGameObjects = currentScene.GetRootGameObjects();
                Flowchart characFlowchart = null;
                Flowchart itemFlowchart = null;
                foreach (GameObject go in rootGameObjects)
                {
                    GameObject c1 = go.transform.Find("Char-Flowcharts").gameObject;
                    GameObject c2 = go.transform.Find("Item-Flowchart").gameObject;
                    if (c1 != null) characFlowchart = c1.GetComponent<Flowchart>();
                    if (c2 != null) itemFlowchart = c2.GetComponent<Flowchart>();
                }
                
                UnityEngine.Debug.LogWarning(characFlowchart);
                UnityEngine.Debug.LogWarning(itemFlowchart);
                UnityEngine.Debug.LogWarning("TAKE ON UNITY");
             /*   itemFlowchart.SetBooleanVariable("IsPluggedIn", saveGame.IsPluggedIn);
                UnityEngine.Debug.LogWarning("TAKE ON UNITY");
                itemFlowchart.SetBooleanVariable("IsBelt", saveGame.IsBelt);
                UnityEngine.Debug.LogWarning("TAKE ON UNITY");
                itemFlowchart.SetBooleanVariable("IsMachine", saveGame.IsMachine);
                UnityEngine.Debug.LogWarning("TAKE ON UNITY");
                characFlowchart.SetStringVariable("CURRENT_STATE", saveGame.CURRENT_STATE);
                UnityEngine.Debug.LogWarning("TAKE ON UNITY");
                characFlowchart.SetIntegerVariable("RNG", saveGame.RNG);
                UnityEngine.Debug.LogWarning("TAKE ON UNITY");
                _gameManager.ScoreManager = saveGame.ScoreManager;
                UnityEngine.Debug.LogWarning("TAKE ON UNITY");
                _gameManager.ScoreManager._stopwatch = new Stopwatch();
                UnityEngine.Debug.LogWarning("TAKE ON UNITY");
                _gameManager.ScoreManager.resume();
                UnityEngine.Debug.LogWarning("TAKE ON UNITY");*/
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
