using Obstacles;
using UnityEngine;

namespace Weapons
{
    public class Bullet : Projectile
    {
        protected override void OnHitObject(GameObject colliderGameObject)
        {
            var asteroid = AsteroidsPool.Instance.GetObstacleController(colliderGameObject);
            asteroid?.TryDamage();
            base.OnHitObject(colliderGameObject);
            BulletPooler.Instance.ReturnObjectToPool(this);
        }
    }
}