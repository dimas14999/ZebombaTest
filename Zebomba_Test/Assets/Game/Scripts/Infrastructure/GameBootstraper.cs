using Game.Scripts.Game.Core;
using Game.Scripts.Game.Factory;
using Game.Scripts.Infrastructure.AssetsManagement;
using Game.Scripts.Infrastructure.States;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Infrastructure
{
    public class GameBootstraper : MonoBehaviour
    {
        private GameStateMachine _stateMachine;
        private SceneLoader _sceneLoader;
        private IAssets _assets;
        private Game.Core.Game _game;
        private IGameFactory _gameFactory;
        private ScoreData _scoreData;
        
        [Inject]
        private void Construct(
            GameStateMachine stateMachine,
            SceneLoader sceneLoader,
            IAssets assets,
            Game.Core.Game game,
            IGameFactory gameFactory,
            ScoreData scoreData
        )
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _assets = assets;
            _game = game;
            _gameFactory = gameFactory;
            _scoreData = scoreData;
        }

        private void Start()
        {
            _stateMachine.RegisterState(new GameBootstrapState(_stateMachine, _assets));
            _stateMachine.RegisterState(new LoadLevelState(_sceneLoader, _stateMachine));
            _stateMachine.RegisterState(new MainMenuState(_gameFactory, _stateMachine));
            _stateMachine.RegisterState(new GameState(_game));
            _stateMachine.RegisterState(new GameOverState(_gameFactory, _stateMachine, _scoreData));
            _stateMachine.Enter<GameBootstrapState>();
            
            DontDestroyOnLoad(this);
        }
    }
}
