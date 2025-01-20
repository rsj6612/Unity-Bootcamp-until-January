using System.Collections.Generic;
using Unity.VisualScripting;

public static class StateFactory
{
    public static List<IState> CreateStates(this StateMachine stateMachine, StaterType staterType)
    {
        List<IState> states = new List<IState>();
        
        switch (staterType)
        {
            case StaterType.Player:
            {
                states.Add(stateMachine.AddComponent<IdleState>());
                states.Add(stateMachine.AddComponent<WalkState>());
                states.Add(stateMachine.AddComponent<JumpState>());
            }
                break;
            case StaterType.Monster:
            {
                states.Add(stateMachine.AddComponent<IdleState_MonsterJ>());
                states.Add(stateMachine.AddComponent<WalkState_MonsterJ>());
                states.Add(stateMachine.AddComponent<SkillState_MonsterJ>());
                states.Add(stateMachine.AddComponent<ChaseState_MonsterJ>());
            }
                break;
        }

        return states;
    }
}