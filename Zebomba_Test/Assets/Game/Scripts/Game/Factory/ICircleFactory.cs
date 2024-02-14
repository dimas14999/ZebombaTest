using System.Threading.Tasks;
using Game.Scripts.Game.Controller;
using UnityEngine;

namespace Game.Scripts.Game.Factory
{
    public interface ICircleFactory
    {
        Task<Circle> CreateCircle(Transform parent);
    }
}
