using Obstacles;
using UnityEngine;

namespace Weapons
{
    public class Laser : Projectile
    {
        protected override void OnHitObject(GameObject colliderGameObject)
        {
            base.OnHitObject(colliderGameObject);
            var asteroid = AsteroidsPool.Instance.GetObstacleController(colliderGameObject);
            asteroid?.DestroyObstacle();
            LaserPooler.Instance.ReturnObjectToPool(this);
        }
    }
}