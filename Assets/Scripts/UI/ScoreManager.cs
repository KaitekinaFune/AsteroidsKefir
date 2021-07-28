using System;
using Obstacles;
using ScriptableObjects;

namespace UI
{
    public static class ScoreManager
    {
        private const int scorePerAsteroidShattered = 1;
        private const int scorePerAsteroidDestroyed = 2;
        private const int scorePerUfoDestroyed = 3;

        public static event Action<int> OnScoreChanged;

        public static int score { get; private set; }

        public static void Initialize()
        {
            Asteroid.OnAsteroidShattered += OnAsteroidShattered;
            Asteroid.OnAsteroidDestroyed += OnAsteroidDestroyed;
            Ufo.OnUfoDestroyed += OnUfoDestroyed;

            GameEventSystem.OnGameRestart += ResetScore;
        }

        private static void ResetScore()
        {
            score = 0;
            OnScoreChanged?.Invoke(score);

        }
        
        private static void OnAsteroidShattered(Asteroid asteroid)
        {
            score += scorePerAsteroidShattered;
            OnScoreChanged?.Invoke(score);
        }
        
        private static void OnAsteroidDestroyed()
        {
            score += scorePerAsteroidDestroyed;
            OnScoreChanged?.Invoke(score);
        }
        
        private static void OnUfoDestroyed()
        {
            score += scorePerUfoDestroyed;
            OnScoreChanged?.Invoke(score);
        }
    }
}