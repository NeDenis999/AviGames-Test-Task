using System;
using UnityEngine;

namespace Game
{
    public class GameDataContainer : MonoBehaviour
    {
        public GameData GameData;
    }
    
    [Serializable]
    public class GameData
    {
        public float Volume;
        public int Difference;
        public int StartDifference;
        public int Level = 1;
    }
}