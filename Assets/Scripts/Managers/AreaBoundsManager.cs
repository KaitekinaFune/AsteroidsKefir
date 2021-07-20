using UnityEngine;

namespace Managers
{
    public class AreaBoundsManager : MonoBehaviour
    {
        [SerializeField] private Transform objectToLock;

        private float screenHalfWidthInWorldUnits;
        private float screenHalfHeightInWorldUnits;
    
        private void Awake()
        {
            var halfObjectWidth = transform.localScale.x / 2f;
            var halfObjectHeight = transform.localScale.y / 2f;
            screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfObjectWidth;
            screenHalfHeightInWorldUnits = Camera.main.orthographicSize + halfObjectHeight;
        }

        private void Update()
        {
            if (objectToLock.position.x < -screenHalfWidthInWorldUnits)
            {
                objectToLock.position = new Vector2(screenHalfWidthInWorldUnits, objectToLock.position.y);
            }
            if (objectToLock.position.x > screenHalfWidthInWorldUnits)
            {
                objectToLock.position = new Vector2(-screenHalfWidthInWorldUnits, objectToLock.position.y);
            }
            if (objectToLock.position.y < -screenHalfHeightInWorldUnits)
            {
                objectToLock.position = new Vector2(objectToLock.position.x, screenHalfHeightInWorldUnits);
            }   
            if (objectToLock.position.y > screenHalfHeightInWorldUnits)
            {
                objectToLock.position = new Vector2(objectToLock.position.x, -screenHalfHeightInWorldUnits);
            }
        }
    }
}
