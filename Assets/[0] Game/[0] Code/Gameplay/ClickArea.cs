using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Game
{
    public class ClickArea : MonoBehaviour, IPointerClickHandler
    {
        [Inject] 
        private MarkerFactory _markerFactory;

        [Inject]
        private AssetProvider assetProvider;

        [Inject]
        private GameDataContainer _gameDataContainer;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            
            if (hit.collider != null && hit.transform.TryGetComponent(out Difference difference))
            {
                if (difference.TryClick())
                {
                    _markerFactory.Spawn(Camera.main.WorldToScreenPoint(difference.transform.position));
                    _markerFactory.Spawn(Camera.main.WorldToScreenPoint(difference.Pair.transform.position));

                    Instantiate(assetProvider.ClickTrueEffect, mousePosition, Quaternion.identity);
                    _gameDataContainer.GameData.Difference++;
                    EventBus.DifferenceUpgrade?.Invoke(_gameDataContainer.GameData.Difference, _gameDataContainer.GameData.StartDifference);
                }
            }
            else
            {
                Instantiate(assetProvider.ClickFalseEffect, mousePosition, Quaternion.identity);
            }
        }
    }
}