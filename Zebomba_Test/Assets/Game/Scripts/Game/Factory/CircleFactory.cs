using System.Threading.Tasks;
using Game.Scripts.Game.Controller;
using Game.Scripts.Game.Factory;
using Game.Scripts.Game.Model;
using Game.Scripts.Game.View;
using Game.Scripts.Infrastructure.AssetsManagement;
using UnityEngine;

public class CircleFactory : ICircleFactory
{
    private readonly IAssets _assets;
    private readonly CircleModel _circleModel;

    public CircleFactory(IAssets assets, CircleModel circleModel)
    {
        _assets = assets;
        _circleModel = circleModel;
    }
    
    public async Task<Circle> CreateCircle(Transform parent)
    {
        GameObject circleObject = await InstantiateRegisteredAsync(AssetsAddress.Circle, parent);
        var circleView = circleObject.GetComponent<CircleView>();
        Circle circle = new Circle(circleView, _circleModel);
        return circle;
    }
    
    private async Task<GameObject> InstantiateRegisteredAsync(string prefabPath, Transform parent)
    {
        GameObject gameObject = await _assets.InstantiateWithParent(prefabPath, parent);
        return gameObject;
    }
}
