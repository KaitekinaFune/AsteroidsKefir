using UnityEngine;

namespace Obstacles
{
    public abstract class ObstaclesPooler : ObjectPooler<Obstacle>
    {
        public override void ReturnObjectToPool(Obstacle obj)
        {
            base.ReturnObjectToPool(obj);
            obj.gameObject.SetActive(false);
        }

        protected ObstaclesPooler(GameObject objectPrefab) : base(objectPrefab)
        {
        }
    }
}