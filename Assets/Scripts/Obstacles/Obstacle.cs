using Player;
using ScriptableObjects;
using UnityEngine;
using Utils;

namespace Obstacles
{
    public abstract class Obstacle : IPoolable
    {
        protected Rigidbody rb;
        
        public void Launch()
        {
            Enable();
        }
        
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
        
        public override void SetGameObject(GameObject obj)
        {
            base.SetGameObject(obj);
            rb = gameObject.GetComponent<Rigidbody>();
        }
    }
}