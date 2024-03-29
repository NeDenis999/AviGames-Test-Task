using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ScreensManager : MonoBehaviour
    {
        [SerializeField]
        private List<SerializablePair<ScreenType, ScreenBase>> _screensPair;

        public void ShowScreen(ScreenType type)
        {
            foreach (var pair in _screensPair)
            {
                if (pair.Key == type)
                {
                    pair.Value.Show();
                    return;
                }
            }
            
            Debug.LogError("No Screen: " + type);
        }

        public void HideScreen(ScreenType type)
        {
            foreach (var pair in _screensPair)
            {
                if (pair.Key == type)
                {
                    pair.Value.Hide();
                    return;
                }
            }
            
            Debug.LogError("No Screen: " + type);
        }
    }
}