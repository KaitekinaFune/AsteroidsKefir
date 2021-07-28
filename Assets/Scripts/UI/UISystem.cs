using ScriptableObjects;
using UnityEngine;

namespace UI
{
    public class UISystem : MonoBehaviour
    {
        [SerializeField] private GameObject onGameStartUI;
        [SerializeField] private GameObject onInGameUI;
        [SerializeField] private GameObject onGameOverUI;

        private readonly UIElement gameStartUi = new UIElement();
        private readonly UIElement inGameUI = new UIElement();
        private readonly UIElement gameOverUI = new UIElement();

        private void Awake()
        {
            gameStartUi.SetGameObject(onGameStartUI);
            inGameUI.SetGameObject(onInGameUI);
            gameOverUI.SetGameObject(onGameOverUI);
        
            GameEventSystem.OnGameStart += SelectInGameUI;
            GameEventSystem.OnGameRestart += SelectInGameUI;
            GameEventSystem.OnGameEnd += SelectOnGameOverUI;
        
            SelectOnGameStartUI();
        }

        private void SelectOnGameStartUI()
        {
            gameStartUi.Enable();
            inGameUI.Disable();
            gameOverUI.Disable();
        }

        private void SelectInGameUI()
        {
            gameStartUi.Disable();
            inGameUI.Enable();
            gameOverUI.Disable();
        }

        private void SelectOnGameOverUI()
        {
            gameStartUi.Disable();
            inGameUI.Disable();
            gameOverUI.Enable();
        }

        private void OnDisable()
        {
            GameEventSystem.OnGameStart -= SelectInGameUI;
            GameEventSystem.OnGameRestart -= SelectInGameUI;
            GameEventSystem.OnGameEnd -= SelectOnGameOverUI;
        }
    }
}
