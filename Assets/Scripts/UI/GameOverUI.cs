using Player;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    private void Start()
    {
        RespawnManager.Instance.OnDeath += OnDeath;
        RespawnManager.Instance.OnRespawn += OnRespawn;
            
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        RespawnManager.Instance.OnDeath -= OnDeath;
        RespawnManager.Instance.OnRespawn -= OnRespawn;
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
