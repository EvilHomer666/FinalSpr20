using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Custom name space not inheriting from Misbehavior
namespace Game.ScoreboardData
{
    [Serializable]
    public class ScoreboardSaveData
    {
        // Initialize new list to store scores
        public List<ScoreboardEntryData> highscores = new List<ScoreboardEntryData>();
    }
}
