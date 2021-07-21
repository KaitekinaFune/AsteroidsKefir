using UnityEngine;

namespace Utils
{
    public static class ScreenBounds
    {
        public static float GetScreenHalfWidthInWorldUnits()
        {
            return Camera.main.aspect * Camera.main.orthographicSize;
        }
        
        public static float GetScreenHalfHeightInWorldUnits()
        {
            return Camera.main.orthographicSize;
        }
    }
}