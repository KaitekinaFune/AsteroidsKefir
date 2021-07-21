using System;
using UnityEngine;

namespace Managers
{
    public class GraphicsManager : MonoBehaviour
    {
        public static GraphicsManager Instance { get; private set; }

        public bool is3DOn { get; private set; }

        public event Action OnChangeGraphicsTo2D;
        public event Action OnChangeGraphicsTo3D;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        public void SwitchGraphics()
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

        private void ChangeGraphicsTo2D()
        {
            is3DOn = false;
            OnChangeGraphicsTo2D?.Invoke();
        }
    
        private void ChangeGraphicsTo3D()
        {
            is3DOn = true;
            OnChangeGraphicsTo3D?.Invoke();
        }
    }
}