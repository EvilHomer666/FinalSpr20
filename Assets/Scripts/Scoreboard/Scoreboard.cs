using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO; // << Using system.OI for input output - stream writer and stream reader

// Custom name space not inheriting from Misbehavior
namespace Game.ScoreboardData
{
public class Scoreboard : MonoBehaviour
    {
        [SerializeField] private int maxScoreEntries = 6;
        [SerializeField] private Transform highscoresContainerTransform;
        [SerializeField] private GameObject scoreboardEntryObject;

        // Debugging data
        [Header("Test")]
        [SerializeField] private string testEntryName = "New Name";
        [SerializeField] private int testEntryScore = 0;
        //[SerializeField] ScoreboardEntryData testEntryData = new ScoreboardEntryData();

        // Set path to save data on the user's PC
        private string SavePath => $"{Application.persistentDataPath}/highscores.json";

        // Start is called before the first frame update
        private void Start()
        {
            // Retrieve current scores from file
           ScoreboardSaveData savedScores = GetSavedScores();

            // Update the UI by displaying the scores if they exist
            UpdateUI(savedScores);
            SaveScores(savedScores);
        }

        // Debugging method - <<<<<<<<<<<<<<<<<< delete or comment out later! O_O
        [ContextMenu("Add Test Entry")]
        public void AddTestEntry()
        {
            AddEntry(new ScoreboardEntryData()
            {
                entryName = testEntryName,
                entryScore = testEntryScore
            });
        }


        // Custom method to add entries
        public void AddEntry(ScoreboardEntryData scoreboardEntryData)
        {
            ScoreboardSaveData savedScores = GetSavedScores();
            bool scoreAdded = false;
            // Loop through loaded data
            for (int i = 0; i < savedScores.highscores.Count; i++)
            {
                if(scoreboardEntryData.entryScore > savedScores.highscores[i].entryScore)
                {
                    savedScores.highscores.Insert(i, scoreboardEntryData);
                    scoreAdded = true;
                    break; // << break to not keep adding scores more than once - yay, proper use of break recalled!
                }
            }

            // Check for additional entry space on scoreboard to add, then  if not then remove old
            if(!scoreAdded && savedScores.highscores.Count < maxScoreEntries)
            {
                savedScores.highscores.Add(scoreboardEntryData);
            }

            if(savedScores.highscores.Count > maxScoreEntries)
            {
                savedScores.highscores.RemoveRange(maxScoreEntries, savedScores.highscores.Count - maxScoreEntries);
            }

            // Update UI after checks
            UpdateUI(savedScores);
            SaveScores(savedScores);
        }

        // Custom method to update UI
        private void UpdateUI(ScoreboardSaveData savedScores)
        {
            foreach (Transform child in highscoresContainerTransform)
            {
                Destroy(child.gameObject);
            }
            foreach (ScoreboardEntryData highscore in savedScores.highscores)
            {
                Instantiate(scoreboardEntryObject, highscoresContainerTransform).GetComponent<ScoreboardEntryUI>().Initialize(highscore);
            }
        }

        // Custom method to retrieve score data
        private ScoreboardSaveData GetSavedScores()
        {
            // Check if file exists otherwise create new one
            if (!File.Exists(SavePath))
            {
                File.Create(SavePath).Dispose();
                return new ScoreboardSaveData();
            }
            using (StreamReader stream = new StreamReader(SavePath))
            {
                string json = stream.ReadToEnd();
                return JsonUtility.FromJson<ScoreboardSaveData>(json);
            }
        }

        // Custom method to save sore data
        private void SaveScores(ScoreboardSaveData scoreboardSaveData)
        {
            using (StreamWriter stream = new StreamWriter(SavePath))
            {
                string json = JsonUtility.ToJson(scoreboardSaveData, true); // << true boolean to enable neat writing
                stream.Write(json);
            }
        }
    }
}
