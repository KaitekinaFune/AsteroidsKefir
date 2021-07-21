using System;
using UnityEngine;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance { get; private set; }
        
        [SerializeField] private int scorePerAsteroidShattered;
        [SerializeField] private int scorePerAsteroidDestroyed;
        [SerializeField] private int scorePerUfoDestroyed;

        private int score;

        public event Action<int> OnScoreChanged;
        
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

        private void Start()
        {
            RespawnManager.Instance.OnRespawn += OnRespawn;
        }

        private void OnDisable()
        {
            RespawnManager.Instance.OnRespawn -= OnRespawn;
        }

        private void OnRespawn()
        {
            score = 0;
            OnScoreChanged?.Invoke(0);
        }
    
        public void OnAsteroidShattered()
        {
            score += scorePerAsteroidShattered;
            OnScoreChanged?.Invoke(score);
        }
    
        public void OnAsteroidDestroyed()
        {
            score += scorePerAsteroidDestroyed;
            OnScoreChanged?.Invoke(score);
        }
        
        public void OnUfoDestroyed()
        {
            score += scorePerUfoDestroyed;
            OnScoreChanged?.Invoke(score);
        }
    }
}