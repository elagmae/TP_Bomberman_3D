using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateFlee : AIStateBase
{
    private AIStateMachine _machine;
    
    public override void Init(AIStateMachine machine, params object[] data)
    {
        if(data.Length > 0) Debug.LogWarning("AIStateFlee not initialized correctly");
        _machine = machine;
    }

    public override void OnStateEnter()
    {
    }

    public override void OnStateUpdate(UpdateType type)
    {
        if (type == UpdateType.NORMAL)
        {
            _machine.Agent.destination = GetFurthestPoint(PlayerManager.Instance.PlayerMains[0].transform.position);
            if (Random.Range(0, 500) == 69)
            {
                _machine.TransitionToState(States.PICKUP);
            }
        }
    }

    private Vector3 GetFurthestPoint(Vector3 basePos)
    {
        if (basePos.x < -15 || basePos.x > 15 || basePos.z < -32 || basePos.z > -12) return basePos;
        
        Vector3 furthestPoint = basePos;
        for (int x = -15; x <= 15; x++)
        {
            for (int y = -32; y <= -12; y++)
            {
                float distance = Vector3.Distance(basePos, new Vector3(x, basePos.y, y));
                float furthestDistance =
                    Vector3.Distance(basePos, new Vector3(furthestPoint.x, basePos.y, furthestPoint.z));

                if (distance > furthestDistance)
                {
                    furthestPoint = new Vector3(x, basePos.y, y);
                }
            }
        }

        return furthestPoint;
    }

    public override void OnStateExit()
    {
    }
}
