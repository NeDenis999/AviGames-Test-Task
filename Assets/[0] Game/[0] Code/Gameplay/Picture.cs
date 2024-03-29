using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class Picture : MonoBehaviour
    {
        private List<Difference> _differences = new List<Difference>();

        public IEnumerable<Difference> Differences => _differences;

        public void Awake()
        {
            _differences = GetComponentsInChildren<Difference>().ToList();
        }
        
        public void Init(Picture picture)
        {
            picture.Copy(this);

            for (int i = 0; i < _differences.Count; i++)
            {
                var difference = _differences[i];
                difference.Init(this, picture.Differences.ToArray()[i]);
            }
        }

        public void Copy(Picture picture)
        {
            for (int i = 0; i < _differences.Count; i++)
            {
                var difference = _differences[i];
                difference.Init(this, picture.Differences.ToArray()[i]);
                difference.Hide();
            }
        }
    }
}