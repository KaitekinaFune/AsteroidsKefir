using UnityEngine;
using Obstacles;

namespace Weapons
{
    public class ProjectilePooler<T> : ObjectPooler<Projectile> where T: Projectile, new()
    {
        protected override void AddObjects()
        {
            var obstacleObject = Object.Instantiate(objectPrefab);
            var obstacle = new T();
            obstacle.SetGameObject(obstacleObject);
            ReturnObjectToPool(obstacle);
            objectsDict.Add(obstacleObject, obstacle);
        }

        public ProjectilePooler(GameObject objectPrefab) : base(objectPrefab)
        {
        }
    }
}