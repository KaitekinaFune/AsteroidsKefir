using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreUI : MonoBehaviour
    {
        private TextMeshProUGUI tmp;

        private void Start()
        {
            tmp = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            ScoreManager.OnScoreChanged += OnScoreChanged;
        }

        private void OnDisable()
        {
            ScoreManager.OnScoreChanged -= OnScoreChanged;
        }

        private void OnScoreChanged(int newScore)
        {
            tmp.SetText($"{newScore}");
        }
    }
}