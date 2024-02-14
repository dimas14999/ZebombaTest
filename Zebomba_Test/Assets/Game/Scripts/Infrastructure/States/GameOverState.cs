using Game.Scripts.Game.Core;
using Game.Scripts.Game.Factory;

namespace Game.Scripts.Infrastructure.States
{
    public class GameOverState : IState
    {
        private readonly IGameFactory _gameFactory;
        private readonly GameStateMachine _gameStateMachine;
        private readonly ScoreData _scoreData;
        private LoseMenu _loseMenu;
        public GameOverState(IGameFactory gameFactory, GameStateMachine gameStateMachine, ScoreData scoreData)
        {
            _gameFactory = gameFactory;
            _gameStateMachine = gameStateMachine;
            _scoreData = scoreData;
        }

        public async void Enter()
        {
            _loseMenu = await _gameFactory.CreateLoseMenu();
            _loseMenu.Init(_gameStateMachine, _scoreData);
        }
        
        public void Exit()
        {
            _loseMenu.Destroy();
        }
    }
}