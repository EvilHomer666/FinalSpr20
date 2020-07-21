using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Custom name space not inheriting from Mono behavior
namespace Game.ScoreboardData
{
    [Serializable]
    // Using a struct instead of a class in order to hold value as opposed to just a reference
    public struct ScoreboardEntryData
    {
        public string entryName;
        public int entryScore;
        public float entryTime;
    }
}
