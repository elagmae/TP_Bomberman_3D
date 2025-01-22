using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public enum States
{
    CHASE,
    FLEE,
    BOMB,
    PICKUP
}

public class AIStateMachine : MonoBehaviour
{
    private AIStateBase _currentState;
    private List<AIStateBase> _states = new(){ new AIStateChase(), new AIStateFlee(), new AIStateBomb(), new AIStatePickup() };

    [field: SerializeField]
    public NavMeshAgent Agent { get; private set; }
    
    [SerializeField, Dropdown("GetStates")] private string _defaultState;
    private List<string> GetStates() => _states.ConvertAll(input => input.GetType().Name);
    
    private void Awake()
    {
        _states[0].Init(this);
        _states[1].Init(this);
        _states[2].Init(this, this.GetComponent<PlayerInventoryBehaviour>(), this.GetComponent<PlayerBombActivation>());
        _states[3].Init(this, this.GetComponent<PlayerInventoryBehaviour>());
        
        _currentState = _states.Find(input => input.GetType().Name == _defaultState);
        _currentState.OnStateEnter();
    }

    public void TransitionToState(States newState)
    {
        _currentState.OnStateExit();
        _currentState = _states[(int)newState];
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
