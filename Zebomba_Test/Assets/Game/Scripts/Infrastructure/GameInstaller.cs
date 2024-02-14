using Game.Scripts.Config;
using Game.Scripts.Game.Core;
using Game.Scripts.Game.Factory;
using Game.Scripts.Game.Model;
using Game.Scripts.Infrastructure.AssetsManagement;
using Game.Scripts.Infrastructure.Service;
using Game.Scripts.Infrastructure.States;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Infrastructure
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private CircleConfig _circleConfig;
        [SerializeField] private PendulumConfig _pendulumConfig;
        [SerializeField] private GameConfig _gameConfig;

        public override void InstallBindings()
        {
            BindGameStateMachine();
            BindFactory();
            BindSceneLoader();
            BindAssetProvider();
            BindConfig();
            BindModel();
            BindData();
            BindInputService();
            BindControls();
        }

        private void BindGameStateMachine()
        {
            Container.Bind<GameStateMachine>().AsSingle();
        }
        
        private void BindFactory()
        {
            Container.BindInterfacesAndSelfTo<GameFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<CircleFactory>().AsSingle();
        }
        
        private void BindSceneLoader()
        {
            Container.Bind<SceneLoader>().AsSingle();
            Container.Bind<Game.Core.Game>().AsSingle();
        }
        
        private void BindAssetProvider()
        {
            Container.BindInterfacesAndSelfTo<AssetProvider>().AsSingle();
        }

        private void BindConfig()
        {
            Container.Bind<CircleConfig>().FromInstance(_circleConfig);
            Container.Bind<PendulumConfig>().FromInstance(_pendulumConfig);
            Container.Bind<GameConfig>().FromInstance(_gameConfig);
        }

        private void BindModel()
        { 
            Container.Bind<PendulumModel>().AsSingle();
            Container.Bind<CircleModel>().AsSingle();
        }
        
        private void BindData()
        {
            Container.Bind<ScoreData>().AsSingle();
        }
        
        private void BindInputService()
        {
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
        }
        
        private void BindControls()
        {
            Controls controls = new Controls();
            Container.Bind<Controls>().FromInstance(controls).AsSingle();
            controls.Enable();
        }
    }
}
