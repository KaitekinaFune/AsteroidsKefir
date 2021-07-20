using System;
using UnityEngine;

namespace Graphics
{
    public class GraphicsManager : MonoBehaviour
    {
        public static GraphicsManager Instance { get; private set; }
    
        public bool is3DOn { get; private set; }

        public event Action OnChangeGraphics2D;
        public event Action OnChangeGraphics3D;

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

        public void ChangeGraphics2D()
        {
            is3DOn = false;
            OnChangeGraphics2D?.Invoke();
        }
    
        public void ChangeGraphics3D()
        {
            is3DOn = true;
            OnChangeGraphics3D?.Invoke();
        }
    }
}