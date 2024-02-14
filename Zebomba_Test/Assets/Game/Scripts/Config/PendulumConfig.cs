using UnityEngine;

namespace Game.Scripts.Config
{
    [CreateAssetMenu(fileName = "PendulumConfig", menuName = "Config/PendulumConfig")]
    public class PendulumConfig : ScriptableObject
    {
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public int Limit { get; private set; }
    }
}
