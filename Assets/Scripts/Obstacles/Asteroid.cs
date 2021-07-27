using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Obstacles
{
    public class Asteroid : Obstacle
    {
        public float initialSpeed { get; private set; }
        private bool isShattered;
        
        public event Action<Asteroid> OnAsteroidShattered;
        
        public void SetSize(Vector3 scale)
        {
            gameObject.transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360f);
            gameObject.transform.localScale = scale;
        }
        
        public void FirstLaunch(Vector3 direction, float speed)
        {
            isShattered = false;
            initialSpeed = speed;
            Launch(direction, speed);
        }

        public void LaunchShattered(Vector3 direction, float speed)
        {
            isShattered = true;
            Launch(direction, speed);
        }

        private void Launch(Vector3 direction, float speed)
        {
            rb.velocity = Vector3.zero;
            gameObject.SetActive(true);
            rb.AddForce(direction * speed);
            Enable();
        }

        public override void DestroyObstacle()
        {
            Disable();
            //ScoreManager.Instance.OnAsteroidDestroyed();
            AsteroidsPool.Instance.ReturnObjectToPool(this);
        }

        public override void TryDamage()
        {
            if (isShattered)
            {
                DestroyObstacle();
                return;
            }

            //ScoreManager.Instance.OnAsteroidShattered();
            OnAsteroidShattered?.Invoke(this);
            OnAsteroidShattered = null;
        }

        public void DestroyObstacleSilent()
        {
            AsteroidsPool.Instance.ReturnObjectToPool(this);
        }
    }
}