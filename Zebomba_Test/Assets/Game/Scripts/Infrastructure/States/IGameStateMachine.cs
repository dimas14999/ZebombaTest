using System.Threading.Tasks;

namespace Game.Scripts.Infrastructure.States
{
    public interface IGameStateMachine
    {
        void RegisterState<TState>(TState state) where TState : IExitableState;
        void Enter<TState>() where TState : class, IState;
        void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>;
    }
}