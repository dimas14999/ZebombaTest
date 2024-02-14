using Game.Scripts.Infrastructure.States;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Game.Core
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Transform _anchor;
        [SerializeField] private Vector3 _anchorPos;
        [SerializeField] private Button _playButton;

        private GameStateMachine _stateMachine;

        private void OnEnable()
        {
         _playButton.onClick.AddListener(OnPlayHandler);   
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(OnPlayHandler);
        }

        private void Start()
        {
            _anchor.transform.localPosition = _anchorPos;
        }

        public void Init(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Exit()
        {
            Destroy(gameObject);
        }
        
        private void OnPlayHandler()
        {
            _stateMachine.Enter<GameState>();
        }
    }
}
