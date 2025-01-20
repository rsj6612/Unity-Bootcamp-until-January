using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CommonState_MonsterJ : MonoBehaviour , IState
{
    public StateMachine Fsm { get; set; }
    public Blackboard_Monster Blackboard { get; set; }
    public void InitState(IBlackboardBase blackboard)
    {
        Blackboard = blackboard as Blackboard_Monster;
    }

    public virtual void Enter()
    {
        throw new System.NotImplementedException();
    }

    public virtual void UpdateState(float deltaTime)
    {
        throw new System.NotImplementedException();
    }

    public virtual void Exit()
    {
        throw new System.NotImplementedException();
    }
}
