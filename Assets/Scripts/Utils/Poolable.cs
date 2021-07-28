using UnityEngine;

namespace Utils
{
    public abstract class Poolable
    {
        public GameObject gameObject { get; private set; }
        
        private float horizontalBounds;
        private float verticalBounds;
        
        public virtual void SetGameObject(GameObject obj)
        {
            gameObject = obj;

            var localScale = gameObject.transform.localScale;
            var objectWidthDoubled = localScale.x * 2f;
            var objectHeightDoubled = localScale.y * 2f;
            
            horizontalBounds = ScreenBounds.GetScreenHalfWidthInWorldUnits() + objectWidthDoubled;
            verticalBounds = ScreenBounds.GetScreenHalfHeightInWorldUnits() + objectHeightDoubled;

            GameEventSystem.OnUpdate += OnUpdate;
        }

        protected virtual void OnUpdate()
        {
            if (!gameObject.activeSelf)
            {
                return;
            }
            
            if (!IsInBounds())
            {
                ReturnObjectToPool();
            }
        }
        
        private bool IsInBounds()
        {
            if (gameObject.transform.position.x < -horizontalBounds)
            {
                return false;
            }
            if (gameObject.transform.position.x > horizontalBounds)
            {
                return false;
            }
            if (gameObject.transform.position.y < -verticalBounds)
            {
                return false;
            }   
            if (gameObject.transform.position.y > verticalBounds)
            {
                return false;
            }

            return true;
        }

        protected abstract void ReturnObjectToPool();
    }
}