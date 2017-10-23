using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UIs
{
    /// <summary>
    /// Win/Lose Interface handler. It shows the player's score (time taken) and quits for them when they're ready
    /// .</summary>
    [Serializable()]
    class Score : Interface
    {
        /// <summary>
        /// Text field to change with time.</summary>
        public Text scoretext;
        public Text finalMessage;
        public Text content;
        public Text playerName;
        public List<ScoreEntry> _scores;
        public long playerScore;
        
        string FileName = Application.persistentDataPath + "scores";  
        
        /// <summary>
        /// Take the time taken by the player and place in the text field.</summary>
        private void Start()
        {
            playerScore = GameManager.inst.timeSinceStart() / 1000 + GameManager.inst.ScoreManager.currentScore();
            scoretext.text = "Time Taken: " + GameManager.inst.timeSinceStart()/1000 + " seconds, Total Score: " + playerScore;
            if (GameManager.inst.won())
            {
                finalMessage.text = "Sam was swiftly arrested once Brange recovered from fainting. Despite losing " +
                                    "Bertha, he was grateful for your support. Bertha's memorial was held at " +
                                    "B.A.D. Manor seven days later, and was attended by all who have worked with " +
                                    "her in the past. She is survived by her husband Brange A. Davenport and her " +
                                    "son Charles F. Davenport. ";
            }
            else
            {
                finalMessage.text = "Your flawed reasoning allowed Sam to enjoy the rest of the party. On the very " +
                                    "next day, he left the mansion with a large sum of money -- which he promptly " +
                                    "lost within a week in the casino. Whether he won in the long run cannot be " +
                                    "accurately determined. Who you thought was the suspect took Sam's place in " +
                                    "prison for the next twelve years.";
            }
            loadScores();
        }

        /// <summary>
        /// Quits the game for the user.</summary>
        public void Quit()
        {
            _scores.Add(new ScoreEntry(playerName.text, playerScore));
            saveScores();
            Application.Quit();
        }

        private void loadScores()
        {
            if (File.Exists(FileName))  
            {  
                Stream scoFileStream = File.OpenRead(FileName);  
                BinaryFormatter deserializer = new BinaryFormatter();  
                _scores = (List<ScoreEntry>)deserializer.Deserialize(scoFileStream);  
                scoFileStream.Close();
            }
            _scores.Sort();
            foreach (ScoreEntry s in _scores)
            {
                content.text += s.Name + ": " + s.score + "\n";
            }
            RectTransform rt = content.GetComponent<RectTransform>();
            float height = rt.sizeDelta.y;
            rt.localPosition = new Vector3(rt.localPosition.x, 0f,  0f);
        }

        private void saveScores()
        {
            Stream scoreFileStream = File.Create(FileName);  
            BinaryFormatter serializer = new BinaryFormatter();  
            serializer.Serialize(scoreFileStream, _scores);  
            scoreFileStream.Close();  
        }
    }

    [Serializable()] 
    public class ScoreEntry : IComparable<ScoreEntry>
    {
        public String Name;
        public long score;

        public ScoreEntry(String namge, long score)
        {
            Name = namge;
            this.score = score;
        }

        public int CompareTo(ScoreEntry other)
        {
            return score.CompareTo(other.score);
        }
    }
}
