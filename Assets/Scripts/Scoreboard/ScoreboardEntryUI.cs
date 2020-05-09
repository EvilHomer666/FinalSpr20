using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Custom name space not inheriting from Misbehavior
namespace Game.ScoreboardData

{
    public class ScoreboardEntryUI : MonoBehaviour
    {
        [SerializeField] private Text entryNameText = null;
        [SerializeField] private Text entryScoreText = null;
        [SerializeField] private Text entryTimeText = null;

        // Custom method to pass data
        public void Initialize(ScoreboardEntryData scoreboardEntryData)
        {
            entryNameText.text = scoreboardEntryData.entryName;
            entryScoreText.text = scoreboardEntryData.entryScore.ToString(); // << Convert to string to display on the screen
            entryTimeText.text = scoreboardEntryData.entryTime.ToString(); // << Convert to string to display on the screen
        }

    }
}
