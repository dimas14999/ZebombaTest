using System.Threading.Tasks;
using UnityEngine;

namespace Game.Scripts.Infrastructure.AssetsManagement
{
    public interface IAssets
    {
        Task InitializeAsync();
        Task<GameObject> Instantiate(string address);
        Task<GameObject> InstantiateWithParent(string address, Transform parent);
    }
}