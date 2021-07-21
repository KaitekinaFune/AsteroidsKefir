using Managers;
using UnityEngine;

namespace Obstacles
{
    public class Ufo : Obstacle
    {
        private float speed;
        private float rotationSpeed;
        
        private Transform target;

        protected override void Awake()
        {
            base.Awake();
            target = UfoTarget.Instance.transform;
        }

        public override void TryDamage()
        {
            DestroyObstacle();
        }

        public override void DestroyObstacle()
        {
            ScoreManager.Instance.OnUfoDestroyed();
            UfosPool.Instance.ReturnObstacleToPool(this);
        }

        public override void DestroyObstacleSilent()
        {
            UfosPool.Instance.ReturnObstacleToPool(this);
        }

        public void Launch()
        {
            gameObject.SetActive(true);
        }

        private void FixedUpdate()
        {
            var direction = target.position - rb.position;
            direction.Normalize();

            var rotateAmount = Vector3.Cross(direction, transform.up);
            rb.angularVelocity = -rotateAmount * rotationSpeed;
            rb.velocity = transform.up * speed;
        }

        public void SetSpeedAndRotation(float speed, float rotationSpeed)
        {
            this.speed = speed;
            this.rotationSpeed = rotationSpeed;
        }
    }
}