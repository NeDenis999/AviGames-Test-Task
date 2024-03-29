using UnityEngine;
using Zenject;

namespace Game
{
    public class MarkerSpawner : MonoBehaviour
    {
        [Inject]
        private MarkerFactory _markerFactory;

        public void Spawn(Vector3 position)
        {
            var maker = _markerFactory.Create();
            maker.transform.position = position;
        }
    }
}