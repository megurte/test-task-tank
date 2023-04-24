using UnityEngine;

namespace Factories
{
    public abstract class GenericFactory<T> : MonoBehaviour where T : MonoBehaviour
    {
        public abstract T SpawnNewObject(Vector2 position);
        
        public abstract void ReturnObjectToPool(T targetObject);
    }
}