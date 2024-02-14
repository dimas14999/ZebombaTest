using Game.Scripts.Game.Model;
using Game.Scripts.Game.View;
using UnityEngine;

namespace Game.Scripts.Game.Controller
{
    public class Circle
    {
        private readonly CircleView _circleView;
        private readonly CircleModel _circleModel;

        public Circle(CircleView circleView, CircleModel circleModel)
        {
            _circleView = circleView;
            _circleModel = circleModel;

            Init();
        }

        private void Init()
        {
            var currentCircleContent = _circleModel.CircleConfig.CircleContents[Random.Range(0, _circleModel.CircleConfig.CircleContents.Count)];
            _circleView.Init(currentCircleContent);
        }

        public void DisconnectCircle(Transform parent)
        {
            _circleView.DisconnectCircle(parent);
        }
    }
}
