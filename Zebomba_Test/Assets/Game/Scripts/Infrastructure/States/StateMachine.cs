using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Game.Scripts.Infrastructure.States
{
    public abstract class StateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states = new Dictionary<Type, IExitableState>();
        private IExitableState _activeState;
        
        public void RegisterState<TState>(TState state) where TState : IExitableState =>
            _states.Add(typeof(TState), state);
        
        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            IPayloadedState<TPayload> state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            if(_activeState != null)
                 _activeState.Exit();
            
            TState state = GetState<TState>();
            _activeState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState => 
            _states[typeof(TState)] as TState;
    }
}