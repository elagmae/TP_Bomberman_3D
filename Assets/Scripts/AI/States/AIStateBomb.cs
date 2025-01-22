using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;

public class AIStateBomb : AIStateBase
{
    private AIStateMachine _machine;
    private PlayerInventoryBehaviour _inventory;
    private PlayerBombActivation _bombActivator;
    
    public override void Init(AIStateMachine machine, params object[] data)
    {
        if (data.Length < 2) { Debug.LogError("Inventory or bomb Has not been provided. Return"); return; }
        if(data.Length > 2) Debug.LogWarning("AIStateFlee not initialized correctly");
        
        _machine = machine;
        _inventory = (PlayerInventoryBehaviour)data[0];
        _bombActivator = (PlayerBombActivation)data[1];
    }

    public override void OnStateEnter()
    {
        if (_inventory.BombInventory.Count == 0)
        {
            _machine.TransitionToState(States.PICKUP);
            return;
        } 
        _bombActivator.ActivateBomb(new InputAction.CallbackContext()); 
        if(PlayerManager.Instance.PlayerMains[0].PlayerInventoryBehaviour.BombInventory.Count > 0) _machine.TransitionToState(States.FLEE);
        else _machine.TransitionToState(States.PICKUP);
    }

    public override void OnStateUpdate(UpdateType type)
    {
    }

    public override void OnStateExit()
    {
    }
}
