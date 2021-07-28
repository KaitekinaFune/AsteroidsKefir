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
            rb.velocity = Vector3.zero;
            gameObject.SetActive(true);
            rb.AddForce(direction * speed);
            Enable();
        }

        public override void DestroyObstacle()
        {
            Disable();
            OnAsteroidDestroyed?.Invoke();
            ObjectPooler<Asteroid>.Instance.ReturnObjectToPool(this);
        }

        public override void TryDamage()
        {
            if (isShattered)
            {
                DestroyObstacle();
                return;
            }

            OnAsteroidShattered?.Invoke(this);
        }

        public void DestroyObstacleSilent()
        {
            ObjectPooler<Asteroid>.Instance.ReturnObjectToPool(this);
        }
    }
}