using System.Linq;
using UnityEngine;

public class AIStatePickup : AIStateBase
{
    private AIStateMachine _machine;
    
    private GameObject[] _bombs;
    private GameObject[] _existingBomb;
    
    private PlayerInventoryBehaviour _playerInventory;
    private int _baseInventoryCount;
    
    public override void Init(AIStateMachine machine, params object[] data)
    {
        if (data.Length < 1) { Debug.LogError("Inventory Has not been provided. Return"); return; }
        if(data.Length > 1) Debug.LogWarning("AIStatePickup not initialized correctly");
        _machine = machine;
        _bombs = GameObject.FindGameObjectsWithTag("Bomb");
        _playerInventory = (PlayerInventoryBehaviour)data[0];
    }

    public override void OnStateEnter()
    {
        _existingBomb = _bombs.Select((b) => b.activeInHierarchy == true ? b : null).ToArray();
        _baseInventoryCount = _playerInventory.BombInventory.Count;
    }

    public override void OnStateUpdate(UpdateType type)
    {
        if (type == UpdateType.NORMAL)
        {
            if (_playerInventory.BombInventory.Count > _baseInventoryCount)
            {
                if (PlayerManager.Instance.PlayerMains[0].PlayerInventoryBehaviour.BombInventory.Count >
                    _playerInventory.BombInventory.Count)
                {
                    if(_bombs.Count(b => b.activeInHierarchy) == 0){
                        _machine.TransitionToState(States.FLEE);
                    }
                    else
                    {
                        _machine.TransitionToState(States.PICKUP);
                    }
                }
                else
                {
                    _machine.TransitionToState(States.CHASE);
                }
            }
            _machine.Agent.destination = GetClosestBomb().transform.position;
        }
    }

    private GameObject GetClosestBomb()
    {
        GameObject closest = _existingBomb.First(o => o != null);
        foreach (var go in _existingBomb)
        {
            if(go == null) continue;
            if (Vector3.Distance(_machine.transform.position, go.transform.position) <
                Vector3.Distance(_machine.transform.position, closest.transform.position))
            {
                closest = go;
            }
        }
        
        return closest;
    }

    public override void OnStateExit()
    {
    }
}
