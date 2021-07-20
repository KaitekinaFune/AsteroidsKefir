using System;
using Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Obstacles
{
    public class Asteroid : Obstacle
    {
        [SerializeField] private float maxLifeTime = 3f;

        private bool isShattered;
        public float initialSpeed { get; private set; }
        
        private Rigidbody rb;
        private float lifeTime;

        public event Action<Asteroid> OnAsteroidShattered;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void SetSize(Vector3 scale)
        {
            transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360f);
            transform.localScale = scale;
        }

        public void SetPosition(Vector3 spawnPoint)
        {
            transform.position = spawnPoint;
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
            lifeTime = 0f;
            gameObject.SetActive(true);
            rb.AddForce(direction * initialSpeed);
        }

        private void Update()
        {
            lifeTime += Time.deltaTime;

            if (lifeTime >= maxLifeTime)
            {
                DestroyObstacle();
            }
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
    }
}