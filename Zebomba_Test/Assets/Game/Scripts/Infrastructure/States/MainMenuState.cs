using Game.Scripts.Game;
using Game.Scripts.Game.Core;
using Game.Scripts.Game.Factory;

namespace Game.Scripts.Infrastructure.States
{
    public class MainMenuState : IState
    {
        private readonly IGameFactory _gameFactory;
        private readonly GameStateMachine _gameStateMachine;

        private MainMenu _mainMenu;

        public MainMenuState(IGameFactory gameFactory, GameStateMachine gameStateMachine)
        {
            _gameFactory = gameFactory;
            _gameStateMachine = gameStateMachine;
        }
        
        public async void Enter()
        {
           _mainMenu = await _gameFactory.CreateMainMenu();
           _mainMenu.Init(_gameStateMachine);
        }
        
        public void Exit()
        {
            _mainMenu.Exit();
        }

    }
}