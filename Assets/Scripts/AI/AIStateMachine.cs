using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.AI;

public class AIStateMachine : MonoBehaviour
{
    private AIStateBase _currentState;
    private List<AIStateBase> _states = new(){ new AIStateChase() };

    [field: SerializeField]
    public NavMeshAgent Agent { get; private set; }
    
    [SerializeField, Dropdown("GetStates")] private string _defaultState;
    private List<string> GetStates() => _states.ConvertAll(input => input.GetType().Name);
    
    private void Awake()
    {
        foreach (AIStateBase state in _states)
        {
            state.Init(this);
        }
        _currentState = _states.Find(input => input.GetType().Name == _defaultState);
        _currentState.OnStateEnter();
    }

    public void TransitionToState(AIStateBase newState)
    {
        _currentState.OnStateExit();
        _currentState = newState;
        _currentState.OnStateEnter();
    }

    private void Update()
    {
        _currentState.OnStateUpdate(UpdateType.NORMAL);
    }
    
    private void FixedUpdate()
    {
        _currentState.OnStateUpdate(UpdateType.FIXED);
    }
    
    private void LateUpdate()
    {
        _currentState.OnStateUpdate(UpdateType.LATE);
    }
}
