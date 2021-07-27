using System.Collections.Generic;
using UnityEngine;

namespace Obstacles
{
    public abstract class ObjectPooler<T> where T: class
    {
        public static ObjectPooler<T> Instance;

        private readonly Stack<T> objects = new Stack<T>();
        protected readonly Dictionary<GameObject, T> objectsDict = new Dictionary<GameObject, T>();
        
        protected readonly GameObject objectPrefab;

        protected ObjectPooler(GameObject objectPrefab)
        {
            this.objectPrefab = objectPrefab;
        }
        
        public void Initialize()
        {
            //TODO: CHECK THIS
            Instance = this;
        }

        public IEnumerable<T> Get(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                if (objects.Count == 0)
                {
                    AddObjects();
                }

                yield return objects.Pop();
            }
        }

        protected abstract void AddObjects();
        
        public virtual void ReturnObjectToPool(T obj)
        {
            objects.Push(obj);
        }

        public T GetObstacleController(GameObject obj)
        {
            return objectsDict.ContainsKey(obj) ? objectsDict[obj] : null;
        }
    }
}