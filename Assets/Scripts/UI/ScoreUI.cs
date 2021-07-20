using Managers;
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
            ScoreManager.Instance.OnScoreChanged += OnScoreChanged;
        }

        private void OnDestroy()
        {
            ScoreManager.Instance.OnScoreChanged -= OnScoreChanged;
        }

        private void OnScoreChanged(int newScore)
        {
            tmp.SetText($"{newScore}");
        }
    }
}