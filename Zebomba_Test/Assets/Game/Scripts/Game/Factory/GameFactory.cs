using System.Threading.Tasks;
using Game.Scripts.Game.Core;
using Game.Scripts.Game.View;
using Game.Scripts.Infrastructure.AssetsManagement;
using UnityEngine;

namespace Game.Scripts.Game.Factory
{
    public class GameFactory : IGameFactory
    {
        private IAssets _assetsProvider;
        
        public GameFactory(IAssets assets)
        {
            _assetsProvider = assets;
        }
        
        public async Task<PendulumGame> CreatePendulumGame()
        {
            var game = await InstantiateRegisteredAsync(AssetsAddress.GameState);
            return game.GetComponent<PendulumGame>();
        }

        public async Task<MainMenu> CreateMainMenu()
        {
            var game = await InstantiateRegisteredAsync(AssetsAddress.MainMenuState);
            return game.GetComponent<MainMenu>();
        }

        public async Task<LoseMenu> CreateLoseMenu()
        {
            var game = await InstantiateRegisteredAsync(AssetsAddress.LoseMenuState);
            return game.GetComponent<LoseMenu>();
        }

        public async Task<PendulumView> CreatePendulum(Transform parent)
        {
            var pendulumObject = await InstantiateRegisteredWithParentAsync(AssetsAddress.PendulumContainer, parent);
            return pendulumObject.GetComponent<PendulumView>();
        }

        
        private async Task<GameObject> InstantiateRegisteredWithParentAsync(string prefabPath, Transform parent)
        {
            GameObject gameObject = await _assetsProvider.InstantiateWithParent(prefabPath, parent);
            return gameObject;
        }
        private async Task<GameObject> InstantiateRegisteredAsync(string prefabPath)
        {
            GameObject gameObject = await _assetsProvider.Instantiate(prefabPath);
            return gameObject;
        }
    }
}