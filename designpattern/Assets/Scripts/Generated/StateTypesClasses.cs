using System;
using System.Collections.Generic;
public class StateTypesClasses
{
	public enum StateTypes
	{
		None,
		Chase,
		ChaseState,
		IdleState,
		JumpState,
		Skill,
		SkillState,
		WalkState,
		Max
	}
	private static readonly Dictionary<Type, StateTypes> TypeToState = new()
	{
		[typeof(ChaseState)] = StateTypes.Chase,
		[typeof(ChaseState_MonsterJ)] = StateTypes.ChaseState,
		[typeof(IdleState)] = StateTypes.IdleState,
		[typeof(IdleState_MonsterJ)] = StateTypes.IdleState,
		[typeof(JumpState)] = StateTypes.JumpState,
		[typeof(SkillState)] = StateTypes.Skill,
		[typeof(SkillState_MonsterJ)] = StateTypes.SkillState,
		[typeof(WalkState)] = StateTypes.WalkState,
		[typeof(WalkState_MonsterJ)] = StateTypes.WalkState,
	};
	public static StateTypes GetState<T>() => GetState(typeof(T));
	public static StateTypes GetState(Type type )
	{
		return TypeToState.GetValueOrDefault(type, StateTypes.None);
	}
}
