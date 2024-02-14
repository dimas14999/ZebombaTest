using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts.Infrastructure
{
    public class SceneLoader
    {
        public Task Load(string name, Action onLoaded = null)
        {
            return LoadSceneAsync(name, onLoaded);
        }
        
        private async Task LoadSceneAsync(string name, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == name)
            {
                onLoaded?.Invoke();
                return;
            }

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(name);

            while (!waitNextScene.isDone)
                await Task.Yield();

            onLoaded?.Invoke();
        }
    }
}