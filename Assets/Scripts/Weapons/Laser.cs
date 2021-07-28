using Obstacles;
using UnityEngine;
using Utils;

namespace Weapons
{
    public class Laser : Projectile
    {
        protected override void OnHitObject(GameObject colliderGameObject)
        {
            base.OnHitObject(colliderGameObject);
            var asteroid = ObjectPooler<Asteroid>.Instance.GetObstacleController(colliderGameObject);
            asteroid?.DestroyObstacle();
        }
        
        protected override void ReturnObjectToPool()
        {
            ObjectPooler<Laser>.Instance.ReturnObjectToPool(this);
        }
    }
}