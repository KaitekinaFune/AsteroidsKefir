using UnityEngine;

namespace Obstacles
{
    public abstract class Obstacle
    {
        public GameObject gameObject { get; private set; }
        protected Rigidbody rb;

        protected void Enable()
        {
            GameEventSystem.OnUpdate += OnUpdate;
        }
        
        protected void Disable()
        {
            GameEventSystem.OnUpdate -= OnUpdate;
        }

        private void OnUpdate()
        {
            CheckForCollisions();
            CheckForInbounds();
        }

        private void CheckForInbounds()
        {
            //TODO: 
        }

        public abstract void TryDamage();
        public abstract void DestroyObstacle();
        
        public void SetPosition(Vector3 spawnPoint)
        {
            gameObject.transform.position = spawnPoint;
        }

        private void CheckForCollisions()
        {
            var position = gameObject.transform.position;
            var scale = gameObject.transform.localScale;
            
            var playerPosition = PlayerController.playerShip.transform.position;
            var playerScale = PlayerController.playerShip.transform.localScale;
            
            if (SimpleCollider.Overlaps(position, scale, playerPosition, playerScale))
            {
                GameEventSystem.EndGame();
            }
        }
        
        public void SetGameObject(GameObject obj)
        {
            gameObject = obj;
            rb = gameObject.GetComponent<Rigidbody>();
        }
    }
}