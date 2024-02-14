using Game.Scripts.Game.Model;
using Game.Scripts.Game.View;
using UnityEngine;

namespace Game.Scripts.Game.Controller
{
    public class Pendulum
    {
        private readonly PendulumView _pendulumView;
        private readonly PendulumModel _pendulumModel;

        public Transform Parent => _pendulumView.CircleParent;
        public Pendulum(PendulumView pendulumView, PendulumModel pendulumModel)
        {
            _pendulumView = pendulumView;
            _pendulumModel = pendulumModel;
        }

        public void Update(float time)
        {
            Move(time);
        }

        private void Move(float time)
        {
            float angel = _pendulumModel.PendulumConfig.Limit *
                          Mathf.Sin(time * _pendulumModel.PendulumConfig.Speed);

            _pendulumView.SetRotation(angel);
        }
    }
}
