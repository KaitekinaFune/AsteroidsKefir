using System;
using UnityEngine;

namespace ScriptableObjects
{
    public class GameEventSystem : MonoBehaviour
    {
        public static event Action OnUpdate;
        public static event Action OnGameStart;
        public static event Action OnGameRestart;
        public static event Action OnGameEnd;
        public static event Action OnSwitchGraphics;
    
        public static void StartGame()
        {
            OnGameStart?.Invoke();
        }
        
        public static void EndGame()
        {
            OnGameEnd?.Invoke();
        }

        public void SwitchGraphics()
        {
            OnSwitchGraphics?.Invoke();
        }

        public void RestartGame()
        {
            OnGameRestart?.Invoke();
        }

        private void Update()
        {
            OnUpdate?.Invoke();
        }
    }
}
