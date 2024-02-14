using Zenject;

namespace Game.Scripts.Infrastructure.Service
{
    public class InputService : IInputService
    {
        private Controls _controls;
 
        [Inject]
        private void Construct(Controls controls)
        {
            _controls = controls;
        }

        public bool IsTapPressed() => _controls.MainMap.Touch.IsPressed();
    }
}