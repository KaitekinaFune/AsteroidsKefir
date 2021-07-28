using Obstacles;
using UnityEngine;
using Utils;

namespace Weapons
{
    public class Bullet : Projectile
    {
        protected override void OnHitObject(GameObject colliderGameObject)
        {
            var asteroid = ObjectPooler<Asteroid>.Instance.GetObstacleController(colliderGameObject);
            asteroid?.TryDamage();
            base.OnHitObject(colliderGameObject);
            ReturnObjectToPool();
        }

        protected override void ReturnObjectToPool()
        {
            ObjectPooler<Bullet>.Instance.ReturnObjectToPool(this);
        }
    }
}