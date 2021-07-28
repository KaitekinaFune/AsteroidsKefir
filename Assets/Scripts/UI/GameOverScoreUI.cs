using TMPro;
using UnityEngine;

namespace UI
{
    public class GameOverScoreUI : MonoBehaviour
    {
        private TextMeshProUGUI tmp;

        private void Start()
        {
            tmp = GetComponent<TextMeshProUGUI>();
            GameEventSystem.OnGameEnd += SetFinalScore;
        }

        private void OnDestroy()
        {
            GameEventSystem.OnGameEnd -= SetFinalScore;
        }

        private void SetFinalScore()
        {
            var score = ScoreManager.score;
            tmp.SetText($"{score}");
        }
    }
}