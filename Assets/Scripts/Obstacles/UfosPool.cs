using UnityEngine;

namespace Obstacles
{
    public class UfosPool : ObstaclesPooler
    {
        public UfosPool(GameObject objectPrefab) : base(objectPrefab)
        {
        }

        protected override void AddObjects()
        {
            var obstacleObject = Object.Instantiate(objectPrefab);
            var obstacle = new Ufo();
            obstacle.SetGameObject(obstacleObject);
            ReturnObjectToPool(obstacle);
            objectsDict.Add(obstacleObject, obstacle);
        }
    }
}