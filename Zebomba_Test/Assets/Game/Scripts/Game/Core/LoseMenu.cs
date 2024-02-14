using Game.Scripts.Infrastructure.States;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Game.Core
{
    public class LoseMenu : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _restartButton;

        private GameStateMachine _stateMachine;
        private ScoreData _scoreData;
        
        public void Init(GameStateMachine stateMachine, ScoreData scoreData)
        {
            _stateMachine = stateMachine;
            _scoreData = scoreData;
            _scoreText.text = $"Score: {_scoreData.Score}";
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
        
        private void OnEnable()
        {
            _menuButton.onClick.AddListener(OnMenuHandler);
            _restartButton.onClick.AddListener(OnRestartHandler);
        }
        
        private void OnDisable()
        {
            _menuButton.onClick.RemoveListener(OnMenuHandler);
            _restartButton.onClick.RemoveListener(OnRestartHandler);
        }
        
        private void OnRestartHandler()
        {
            _stateMachine.Enter<GameState>();
        }

        private void OnMenuHandler()
        {
            _stateMachine.Enter<MainMenuState>();
        }
    }
}
