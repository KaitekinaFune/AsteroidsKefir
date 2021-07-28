using System;
using Player;
using UnityEngine;
using Utils;

namespace Obstacles
{
    public class Ufo : Obstacle
    {
        private float speed;
        private float rotationSpeed;
        private Transform target;

        public static event Action OnUfoDestroyed;
        
        public void Launch()
        {
            rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.zero;
            Enable();
        }

        public override void SetGameObject(GameObject obj)
        {
            base.SetGameObject(obj);
            target = PlayerController.playerShip.transform;
        }
        
        protected override void OnUpdate()
        {
            base.OnUpdate();

            if (!gameObject.activeSelf)
            {
                return;
            }
            
            var direction = target.position - rb.position;
            direction.Normalize();

            var up = gameObject.transform.up;
            var rotateAmount = Vector3.Cross(direction, up);
            rb.angularVelocity = -rotateAmount * rotationSpeed * Time.deltaTime;
            rb.velocity = up * speed * Time.deltaTime;
        }
        
        protected override void ReturnObjectToPool()
        {
            ObjectPooler<Ufo>.Instance.ReturnObjectToPool(this);
        }

        public void SetSpeedAndRotation(float speed, float rotationSpeed)
        {
            this.speed = speed;
            this.rotationSpeed = rotationSpeed;
        }
        
        public void DestroyObstacle()
        {
            OnUfoDestroyed?.Invoke();
            ReturnObjectToPool();
        }
    }
}