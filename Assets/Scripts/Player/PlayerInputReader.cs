using System;
using UnityEngine;

namespace Player
{
    public class PlayerInputReader
    {
        public float vertical { get; private set; }
        public float horizontal { get; private set; }

        public event Action OnShootPrimary;
        public event Action OnShootSecondary;

        private bool isActive;

        public void Start()
        {
            isActive = true;
            ResetInput();
        }

        public void Stop()
        {
            isActive = false;
            ResetInput();
        }

        private void ResetInput()
        {
            vertical = 0;
            horizontal = 0;
        }

        public void TryReadInput()
        {
            if (!isActive)
            {
                return;
            }
        
            vertical = Input.GetAxis("Vertical");
            horizontal = Input.GetAxis("Horizontal");

            if (Input.GetAxisRaw("Fire1") > 0)
            {
                OnShootPrimary?.Invoke();
            }

            if (Input.GetAxisRaw("Fire2") > 0)
            {
                OnShootSecondary?.Invoke();
            }
        }
    }
}
