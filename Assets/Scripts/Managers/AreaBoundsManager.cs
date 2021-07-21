using UnityEngine;
using Utils;

namespace Managers
{
    public class AreaBoundsManager : MonoBehaviour
    {
        [SerializeField] private Transform objectToLock;

        private float screenHalfWidthInWorldUnits;
        private float screenHalfHeightInWorldUnits;
    
        private void Awake()
        {
            var localScale = objectToLock.localScale;
            var halfObjectWidth = localScale.x / 2f;
            var halfObjectHeight = localScale.y / 2f;
            
            screenHalfWidthInWorldUnits = ScreenBounds.GetScreenHalfWidthInWorldUnits() + halfObjectWidth;
            screenHalfHeightInWorldUnits = ScreenBounds.GetScreenHalfHeightInWorldUnits() + halfObjectHeight;
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