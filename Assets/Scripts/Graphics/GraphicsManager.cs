using System;
using ScriptableObjects;

namespace Graphics
{
    public static class GraphicsManager
    {
        public static bool is3DOn { get; private set; }

        public static event Action OnChangeGraphicsTo2D;
        public static event Action OnChangeGraphicsTo3D;
        
        public static void Initialize()
        {
            GameEventSystem.OnSwitchGraphics += SwitchGraphics;
        }
        
        private static void SwitchGraphics()
        {
            if (is3DOn)
            {
                ChangeGraphicsTo2D();
            }
            else
            {
                ChangeGraphicsTo3D();
            }
        }

        private static void ChangeGraphicsTo2D()
        {
            is3DOn = false;
            OnChangeGraphicsTo2D?.Invoke();
        }
    
        private static void ChangeGraphicsTo3D()
        {
            is3DOn = true;
            OnChangeGraphicsTo3D?.Invoke();
        }
    }
}