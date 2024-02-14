using System.Threading.Tasks;
using Game.Scripts.Game;
using Game.Scripts.Game.Factory;

namespace Game.Scripts.Infrastructure.States
{
    public class GameState : IState
    {
        private readonly Game.Core.Game _game;

        public GameState(Game.Core.Game game)
        {
            _game = game;
        }
        
        public async void Enter()
        {
            await _game.InitGameWorld();
        }
        
        public void Exit()
        {
            _game.Exit();
        }
    }
}