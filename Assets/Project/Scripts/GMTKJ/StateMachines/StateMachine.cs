using System;
using UnityEngine;

namespace GMTKJ.StateMachines
{
    public abstract class StateMachine<TContext, TState>: 
    IStateMachine<TContext, TState>
    where TState : State<TContext, TState> 
    {
        protected TState CurrentState{get; private set;}
        public TContext Context { get; private set; }
        public abstract TState DefaultState { get; }

        public void Init(TContext context)
        {
            this.Context =context;
            ChangeState(DefaultState);
        }

        void IStateMachine<TContext, TState>.ChangeState(TState nextState)
        {
            ChangeState(nextState);
        }

        private void ChangeState(TState nextState)
        {
            Debug.Assert(nextState != null);
            if(CurrentState != null)
                ((IState<TContext, TState>)CurrentState).End();
            CurrentState = nextState;
            ((IState<TContext, TState>)CurrentState).Init(this);
            ((IState<TContext, TState>)nextState).OnEnter();
        }
    }
    public class State<TContext, TState> : IState<TContext, TState>
    where TState : State<TContext, TState>
    {
        private IStateMachine<TContext, TState> owner;
        protected TContext Context{get{return owner.Context;}}
        protected void ChangeState(TState nextState)
        {
            owner.ChangeState(nextState);
        }


        protected virtual void Begin(){}
        protected virtual void End(){}

        void IState<TContext, TState>.End()
        {
            End();
        }

        void IState<TContext, TState>.OnEnter()
        {
            Begin();
        }

        void IState<TContext, TState>.Init(StateMachine<TContext, TState> stateMachine)
        {
            this.owner = stateMachine;
        }
    }
    
    public interface IStateMachine<TContext, TState>
    where TState : State<TContext, TState>
    {
        TContext Context{get;}
        void ChangeState(TState nextState);
    }
    public interface IState<TContext, TState>
    where TState : State<TContext, TState>
    {
        void OnEnter();
        void End();
        void Init(StateMachine<TContext, TState> stateMachine);
    }
}