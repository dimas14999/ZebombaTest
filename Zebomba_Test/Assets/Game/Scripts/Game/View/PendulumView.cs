using UnityEngine;

namespace Game.Scripts.Game.View
{
    public class PendulumView : MonoBehaviour
    {
        [SerializeField] private Transform _circleParent;

        public Transform CircleParent => _circleParent;
        public void SetRotation(float angel)
        {
            transform.localRotation = Quaternion.Euler(0,0, angel);
        }
    }
}
