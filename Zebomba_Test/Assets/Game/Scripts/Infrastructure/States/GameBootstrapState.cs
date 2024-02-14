using System.Threading.Tasks;
using Game.Scripts.Infrastructure.AssetsManagement;

namespace Game.Scripts.Infrastructure.States
{
    public class GameBootstrapState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IAssets _assets;

        public GameBootstrapState(IGameStateMachine gameStateMachine, IAssets assets)
        {
            _gameStateMachine = gameStateMachine;
            _assets = assets;
        }
        
        public async void Enter()
        {
            await InitServices();

            _gameStateMachine.Enter<LoadLevelState, string>("Game/Scenes/Main");
        }

        private async Task InitServices()
        {
            await _assets.InitializeAsync();
        }
        
        public void Exit()
        {
            
        }
    }
}