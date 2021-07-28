using Player;
using UnityEngine;
using Utils;

namespace Obstacles
{
    public abstract class Obstacle : Poolable
    {
        protected Rigidbody rb;
        
        protected void Enable()
        {
            gameObject.SetActive(true);
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();

            if (!gameObject.activeSelf)
            {
                return;
            }
            
            CheckForCollisions();
        }
        
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