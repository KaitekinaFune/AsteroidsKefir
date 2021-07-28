using Obstacles;
using UnityEngine;
using Utils;

namespace Weapons
{
    public abstract class Projectile : Poolable
    {
        private float speed;
        
        public void Launch(Transform shootPoint, float newSpeed)
        {
            gameObject.SetActive(true);
            gameObject.transform.position = shootPoint.position;
            gameObject.transform.rotation = shootPoint.rotation;
            speed = newSpeed;
        }
        
        protected override void OnUpdate()
        {
            base.OnUpdate();

            if (!gameObject.activeSelf)
            {
                return;
            }
            
            var moveDistance = speed * Time.deltaTime;
            CheckCollisions(moveDistance);
            gameObject.transform.Translate(Vector3.up * moveDistance);
        }

        private void CheckCollisions(float moveDistance)
        {
            var ray = new Ray(gameObject.transform.position, gameObject.transform.up);
                
            if (Physics.Raycast(ray, out var hit, moveDistance + .1f, 1<<8, QueryTriggerInteraction.Collide))
            {
                OnHitObject(hit.collider.gameObject);
            }
        }

        protected virtual void OnHitObject(GameObject colliderGameObject)
        {
            var ufo = ObjectPooler<Ufo>.Instance.GetObstacleController(colliderGameObject);
            ufo?.DestroyObstacle();
        }
    }
}