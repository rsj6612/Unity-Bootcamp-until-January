using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[State("IdleState")]
public class IdleState_MonsterJ : CommonState_MonsterJ
{
    public override void Enter()
    {
        Blackboard.animator.Play("Idles");
        Blackboard.animator.SetFloat("Speed", 0.0f);
    }

    public override void UpdateState(float deltaTime)
    {
        if (Blackboard.target != null)
        {
            Fsm.ChangeState(StateTypesClasses.StateTypes.ChaseState);
        }
    }

    public override void Exit()
    {
        
    }
}
