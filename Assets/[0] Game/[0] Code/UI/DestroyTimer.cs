using System.Collections;
using UnityEngine;

namespace Game
{
    public class DestroyTimer : MonoBehaviour
    {
        [SerializeField]
        private float _seconds;
        
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(_seconds);
            Destroy(gameObject);
        }
    }
}