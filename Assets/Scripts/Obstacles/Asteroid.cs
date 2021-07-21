using System;
using Managers;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

namespace Obstacles
{
    public class Asteroid : Obstacle, IDestroyableByBoundary
    {
        public float initialSpeed { get; private set; }
        
        private bool isShattered;
        
        public event Action<Asteroid> OnAsteroidShattered;

        public void SetSize(Vector3 scale)
        {
            transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360f);
            transform.localScale = scale;
        }
        
        public void FirstLaunch(Vector3 direction, float speed)
        {
            isShattered = false;
            Launch(direction, speed);
        }

        public void LaunchShattered(Vector3 direction, float speed)
        {
            isShattered = true;
            Launch(direction, speed);
        }

        private void Launch(Vector3 direction, float speed)
        {
            initialSpeed = speed;
            gameObject.SetActive(true);
            rb.AddForce(direction * initialSpeed);
        }

        public override void DestroyObstacle()
        {
            ScoreManager.Instance.OnAsteroidDestroyed();
            AsteroidsPool.Instance.ReturnObstacleToPool(this);
        }

        public override void TryDamage()
        {
            if (isShattered)
            {
                DestroyObstacle();
                return;
            }

            ScoreManager.Instance.OnAsteroidShattered();
            OnAsteroidShattered?.Invoke(this);
            OnAsteroidShattered = null;
        }

        public override void DestroyObstacleSilent()
        {
            AsteroidsPool.Instance.ReturnObstacleToPool(this);
        }

        public void OnBoundaryTouch()
        {
            DestroyObstacleSilent();
        }
    }
}