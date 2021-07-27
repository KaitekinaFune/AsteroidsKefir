using System;
using UnityEngine;

public class GameEventSystem : MonoBehaviour
{
    public static event Action OnUpdate;
    public static event Action OnGameStart;
    public static event Action OnGameRestart;
    public static event Action OnGameEnd;
    
    public void StartGame()
    {
        OnGameStart?.Invoke();
    }

    public void RestartGame()
    {
        OnGameRestart?.Invoke();
    }

    public static void EndGame()
    {
        OnGameEnd?.Invoke();
    }

    private void Update()
    {
        OnUpdate?.Invoke();
    }
}
