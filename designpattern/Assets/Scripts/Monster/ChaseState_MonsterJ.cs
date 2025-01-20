using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[State("ChaseState")]
public class ChaseState_MonsterJ : CommonState_MonsterJ
{
    public override void Enter()
    {
    }

    public override void UpdateState(float deltaTime)
    {
        if (Blackboard.target == null)
        {
            Fsm.ChangeState(StateTypesClasses.StateTypes.IdleState);
            return;
        }

        var (skillIndex, skillDistance) = Blackboard.SkillControllerJ.GetAvailableSkillAndDistance();
        if (0 > skillIndex)
        {
            Fsm.ChangeState(StateTypesClasses.StateTypes.IdleState);
            return;
        }
        
        float attackRnageSqr = skillDistance * skillDistance;
        if (Vector3.SqrMagnitude(Blackboard.target.transform.position - Fsm.transform.position) > attackRnageSqr)
        {
            Vector3 newPos = Vector3.MoveTowards(
                Fsm.transform.position, 
                Blackboard.target.transform.position, 
                Blackboard.moveSpeed * deltaTime
                );
            
            Blackboard.rigidbody.MovePosition(newPos);
            return;
        }

        Fsm.ChangeState(StateTypesClasses.StateTypes.SkillState);
    }

    public override void Exit()
    {
        
    }
}
