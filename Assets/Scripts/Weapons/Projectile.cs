using Obstacles;
using UnityEngine;

namespace Weapons
{
    public abstract class Projectile
    {
        private GameObject gameObject;
        private float speed;

        public void SetGameObject(GameObject obj)
        {
            gameObject = obj;
        }

        public void Launch(Transform shootPoint, float newSpeed)
        {
            gameObject.transform.position = shootPoint.position;
            gameObject.transform.rotation = shootPoint.rotation;
            speed = newSpeed;
            GameEventSystem.OnUpdate += OnUpdate;
        }
        
        private void OnUpdate()
        {
            var moveDistance = speed * Time.deltaTime;
            CheckCollisions(moveDistance);
            gameObject.transform.Translate(Vector3.up * speed);
        }
        
        private void CheckCollisions(float moveDistance)
        {
            var ray = new Ray (gameObject.transform.position, gameObject.transform.up);
            
            if (Physics.Raycast(ray, out var hit, moveDistance))
            {
                OnHitObject(hit.collider.gameObject);
            }
        }

        protected virtual void OnHitObject(GameObject colliderGameObject)
        {
            var ufo = UfosPool.Instance.GetObstacleController(colliderGameObject);
            ufo?.DestroyObstacle();
            
            GameEventSystem.OnUpdate -= OnUpdate;
        }
    }
}