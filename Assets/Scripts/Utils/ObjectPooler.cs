using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

namespace Utils
{
    public abstract class IPoolable
    {
        public GameObject gameObject { get; private set; }

        public virtual void SetGameObject(GameObject obj)
        {
            gameObject = obj;
        }
    }
    
    public class ObjectPooler<T> where T: IPoolable, new()
    {
        public static ObjectPooler<T> Instance;

        private readonly Stack<T> objects = new Stack<T>();
        private readonly Dictionary<GameObject, T> objectsDict = new Dictionary<GameObject, T>();

        private readonly GameObject objectPrefab;

        public ObjectPooler(GameObject objectPrefab)
        {
            this.objectPrefab = objectPrefab;
        }
        
        public void Initialize()
        {
            Instance ??= this;
            GameEventSystem.OnGameRestart += ReturnAllObjectsToPool;
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

        private void AddObjects()
        {
            var obstacleObject = Object.Instantiate(objectPrefab);
            var obstacle = new T();
            obstacle.SetGameObject(obstacleObject);
            ReturnObjectToPool(obstacle);
            objectsDict.Add(obstacleObject, obstacle);
        }
        
        public void ReturnObjectToPool(T obj)
        {
            obj.gameObject.SetActive(false);
            objects.Push(obj);
        }

        public T GetObstacleController(GameObject obj)
        {
            return objectsDict.ContainsKey(obj) ? objectsDict[obj] : null;
        }

        private void ReturnAllObjectsToPool()
        {
            foreach (var pair in objectsDict)
            {
                if (pair.Key.activeSelf)
                {
                    ReturnObjectToPool(pair.Value);
                }
            }
        }
    }
}