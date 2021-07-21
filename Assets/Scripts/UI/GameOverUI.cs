using Managers;
using UnityEngine;

namespace UI
{
    public class GameOverUI : MonoBehaviour
    {
        private void Start()
        {
            GameOverManager.Instance.OnDeath += OnDeath;
            GameOverManager.Instance.OnRespawn += OnRespawn;
            
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            GameOverManager.Instance.OnDeath -= OnDeath;
            GameOverManager.Instance.OnRespawn -= OnRespawn;
        }

        private void OnDeath()
        {
            gameObject.SetActive(true);
        }

        private void OnRespawn()
        {
            gameObject.SetActive(false);
        }
    }
}
