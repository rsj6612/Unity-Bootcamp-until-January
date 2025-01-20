using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackboard_Monster : MonoBehaviour, IBlackboardBase
{
    public float moveSpeed = 3.0f;
    public float attackRange = 6.0f;
   
    [NonSerialized] public Animator animator;
    [NonSerialized] public Rigidbody rigidbody;
    [NonSerialized] public SkillControllerJ SkillControllerJ;

    [NonSerialized] public EntityJ target;
        
    public new void InitBlackboard()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();

        SkillControllerJ = GetComponent<SkillControllerJ>();
    }   
}
