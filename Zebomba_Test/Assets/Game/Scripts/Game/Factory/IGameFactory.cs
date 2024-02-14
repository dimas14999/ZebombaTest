using System.Threading.Tasks;
using Game.Scripts.Game.Core;
using Game.Scripts.Game.View;
using UnityEngine;

namespace Game.Scripts.Game.Factory
{
    public interface IGameFactory
    {
        Task<PendulumGame> CreatePendulumGame();
        Task<MainMenu> CreateMainMenu();
        Task<LoseMenu> CreateLoseMenu();
        Task<PendulumView> CreatePendulum(Transform parent);
    }
}