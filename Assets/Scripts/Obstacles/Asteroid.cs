using System;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

namespace Obstacles
{
    public class Asteroid : Obstacle
    {
        public float initialSpeed { get; private set; }
        private bool isShattered;
        
        public static event Action<Asteroid> OnAsteroidShattered;
        public static event Action OnAsteroidDestroyed;
        
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
            Enable();
            rb.velocity = Vector3.zero;
            rb.AddForce(direction * speed);
        }

        public void DestroyObstacle()
        {
            OnAsteroidDestroyed?.Invoke();
            ReturnObjectToPool();
        }

        public void TryDamage()
        {
            if (isShattered)
            {
                DestroyObstacle();
                return;
            }
            
            OnAsteroidShattered?.Invoke(this);
        }

        protected override void ReturnObjectToPool()
        {
            ObjectPooler<Asteroid>.Instance.ReturnObjectToPool(this);
        }
    }
}