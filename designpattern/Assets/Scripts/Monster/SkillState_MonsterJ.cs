using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

[State("SkillState")]
public class SkillState_MonsterJ : CommonState_MonsterJ
{

    public override void Enter()
    {
        Debug.Log("SkillState_MonsterJ.Enter");
        FireSkill();
    }

    public override void UpdateState(float deltaTime)
    {
    }

    public override void Exit()
    {
        Debug.Log("SkillState_MonsterJ.Exit");
    }

    async void FireSkill()
    {
        var (skillIndex, _) = Blackboard.SkillControllerJ.GetAvailableSkillAndDistance();
        if (0 > skillIndex)
        {
            Fsm.ChangeState(StateTypesClasses.StateTypes.IdleState);
            return;
        }
        
        var skillData = Blackboard.SkillControllerJ.FireSkill(skillIndex);
        await UniTask.Delay((int)(skillData.skillDuration * 1000));

        Fsm.ChangeState(StateTypesClasses.StateTypes.IdleState);
    }
}
