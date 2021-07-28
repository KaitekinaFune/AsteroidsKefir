using System;
using Utils;

namespace Obstacles
{
    public class Ufo : Obstacle
    {
        private float speed;
        private float rotationSpeed;

        public static event Action OnUfoDestroyed;
        
        public override void TryDamage()
        {
            DestroyObstacle();
        }

        public override void DestroyObstacle()
        {
            OnUfoDestroyed?.Invoke();
            ObjectPooler<Ufo>.Instance.ReturnObjectToPool(this);
        }

        public void DestroyObstacleSilent()
        {
            ObjectPooler<Ufo>.Instance.ReturnObjectToPool(this);
        }
        
        /*
        private void FixedUpdate()
        {
            var direction = target.position - rb.position;
            direction.Normalize();

            var rotateAmount = Vector3.Cross(direction, gameObject.transform.up);
            rb.angularVelocity = -rotateAmount * rotationSpeed;
            rb.velocity = gameObject.transform.up * speed;
        }

        public void SetSpeedAndRotation(float speed, float rotationSpeed)
        {
            this.speed = speed;
            this.rotationSpeed = rotationSpeed;
        }
        */
    }
}