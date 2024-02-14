
using System.Threading.Tasks;

namespace Game.Scripts.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly SceneLoader _sceneLoader;
        private readonly StateMachine _stateMachine;

        public LoadLevelState(SceneLoader sceneLoader, StateMachine stateMachine)
        {
            _sceneLoader = sceneLoader;
            _stateMachine = stateMachine;
        }

        public async void Enter(string sceneName)
        {
           await _sceneLoader.Load(sceneName, onLoaded: OnLoaded);
        }

        public void Exit()
        {
           
        }
        
        private void OnLoaded()
        {
            _stateMachine.Enter<MainMenuState>();
        }
    }
}