using System.Threading.Tasks;
using Game.Scripts.Game.Controller;
using Game.Scripts.Game.Factory;
using Game.Scripts.Game.Model;
using Game.Scripts.Game.View;
using Game.Scripts.Infrastructure.Service;
using Game.Scripts.Infrastructure.States;
using Zenject;

namespace Game.Scripts.Game.Core
{
    public class Game
    {
        private readonly IGameFactory _gameFactory;
        private readonly PendulumModel _pendulumModel;
        private readonly ICircleFactory _circleFactory;
        private readonly GameConfig _gameConfig;
        private readonly GameStateMachine _gameStateMachine;
        private readonly ScoreData _scoreData;
        private readonly IInputService _inputService;
        private PendulumGame _pendulumGame;
        
        public Game(DiContainer diContainer,
            IGameFactory gameFactory,
            PendulumModel pendulumModel,
            ICircleFactory circleFactory,
            GameConfig gameConfig,
            GameStateMachine gameStateMachine,
            ScoreData scoreData,
            IInputService inputService
            )
        {
            _gameFactory = gameFactory;
            _pendulumModel = pendulumModel;
            _circleFactory = circleFactory;
            _gameConfig = gameConfig;
            _gameStateMachine = gameStateMachine;
            _scoreData = scoreData;
            _inputService = inputService;
        }
        
        public async Task InitGameWorld()
        {
            _pendulumGame = await _gameFactory.CreatePendulumGame();
            PendulumView pendulumView = await InitPendulumView();
            Pendulum pendulum = new Pendulum(pendulumView, _pendulumModel);
            _pendulumGame.Init(pendulum, _circleFactory, _gameConfig, _gameStateMachine, _scoreData, _inputService);
        }
        
        public void Exit()
        {
            _pendulumGame.Destroy();
        }
        
        private async Task<PendulumView> InitPendulumView() => 
            await _gameFactory.CreatePendulum(_pendulumGame.transform);
    }
}