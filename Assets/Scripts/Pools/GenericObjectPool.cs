using System.Collections.Generic;
using UnityEngine;

namespace ColorSwitch.Pools
{
    public class GenericObjectPool<T> : MonoBehaviour where T : Component
    {
        [SerializeField] private T prefab;

        private readonly Queue<T> _pool = new Queue<T>();

        public T Get(Transform parentTransform)
        {
            if (_pool.Count == 0)
            {
                AddObjects(parentTransform);
            }
            
            return _pool.Dequeue();
        }

        public void ReturnToPool(T objectToReturn)
        {
            objectToReturn.gameObject.SetActive(false);
            _pool.Enqueue(objectToReturn);
        }

        private void AddObjects(Transform parentTransform)
        {
            var newObject = Instantiate(prefab, parentTransform);
            newObject.gameObject.SetActive(false);
            _pool.Enqueue(newObject);
        }
    }
}