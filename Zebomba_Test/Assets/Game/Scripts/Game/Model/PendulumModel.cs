using Game.Scripts.Config;

namespace Game.Scripts.Game.Model
{
    public class PendulumModel
    {
        public readonly PendulumConfig PendulumConfig;

        public PendulumModel(PendulumConfig pendulumConfig)
        {
            PendulumConfig = pendulumConfig;
        }
    }
}
