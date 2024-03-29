using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Game
{
    public class ClickArea : MonoBehaviour, IPointerClickHandler
    {
        private MarkerSpawner _markerSpawner;
        private AssetProvider _assetProvider;
        private GameDataContainer _gameDataContainer;

        [Inject]
        private void Construct(MarkerSpawner markerSpawner, AssetProvider assetProvider, GameDataContainer gameDataContainer)
        {
            _markerSpawner = markerSpawner;
            _assetProvider = assetProvider;
            _gameDataContainer = gameDataContainer;
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            
            if (hit.collider != null && hit.transform.TryGetComponent(out Difference difference))
            {
                if (difference.TryClick())
                {
                    _markerSpawner.Spawn(Camera.main.WorldToScreenPoint(difference.transform.position));
                    _markerSpawner.Spawn(Camera.main.WorldToScreenPoint(difference.Pair.transform.position));

                    Instantiate(_assetProvider.ClickTrueEffect, mousePosition, Quaternion.identity);
                    _gameDataContainer.GameData.Difference++;
                    EventBus.DifferenceUpgrade?.Invoke(_gameDataContainer.GameData.Difference, _gameDataContainer.GameData.StartDifference);
                }
            }
            else
            {
                Instantiate(_assetProvider.ClickFalseEffect, mousePosition, Quaternion.identity);
            }
        }
    }
}