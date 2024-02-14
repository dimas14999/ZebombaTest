using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Game.Scripts.Infrastructure.AssetsManagement
{
    public class AssetProvider : IAssets
    {
        public async Task InitializeAsync()
        {
            await Addressables.InitializeAsync().Task;
        }

        public Task<GameObject> Instantiate(string address)
        {
            return Addressables.InstantiateAsync(address).Task;
        }

        public Task<GameObject> InstantiateWithParent(string address, Transform parent)
        {
            return Addressables.InstantiateAsync(address, parent).Task;
        }
    }
}