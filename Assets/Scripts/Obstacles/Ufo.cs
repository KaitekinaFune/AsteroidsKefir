using Managers;

namespace Obstacles
{
    public class Ufo : Obstacle
    {
        private float speed;
        private float rotationSpeed;
        
        public override void TryDamage()
        {
            DestroyObstacle();
        }

        public override void DestroyObstacle()
        {
            ScoreManager.Instance.OnUfoDestroyed();
            UfosPool.Instance.ReturnObjectToPool(this);
        }

        public void DestroyObstacleSilent()
        {
            UfosPool.Instance.ReturnObjectToPool(this);
        }

        public void Launch()
        {
            gameObject.SetActive(true);
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