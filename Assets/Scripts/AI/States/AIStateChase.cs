using UnityEngine;
using UnityEngine.AI;

public class AIStateChase : AIStateBase
{
    private AIStateMachine _machine;
    
    public override void Init(AIStateMachine machine, params object[] data)
    {
        if(data.Length > 0) Debug.LogWarning("AIStateChase not initialized correctly");
        _machine = machine;
    }

    public override void OnStateEnter() { }

    public override void OnStateUpdate(UpdateType type)
    {
        if (type == UpdateType.NORMAL)
        {
            _machine.Agent.destination = new Vector3(0, 0, 0); // TODO: Replace by player position
        }
    }

    public override void OnStateExit() { }
}