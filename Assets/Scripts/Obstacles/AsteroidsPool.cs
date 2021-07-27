using UnityEngine;

namespace Obstacles
{
    public class AsteroidsPool : ObstaclesPooler
    {
        public AsteroidsPool(GameObject objectPrefab) : base(objectPrefab)
        {
        }

        protected override void AddObjects()
        {
            var obstacleObject = Object.Instantiate(objectPrefab);
            var obstacle = new Asteroid();
            obstacle.SetGameObject(obstacleObject);
            ReturnObjectToPool(obstacle);
            objectsDict.Add(obstacleObject, obstacle);
        }
    }
}