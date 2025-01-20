using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SkillCooltimerJ))]
public class SkillInstanceJ : MonoBehaviour
{
    public GameObject Owner;
    public Animator animator;
    public SkillDataJ SkillData;
    
    private SkillCooltimerJ skillCooltimer;

    private void Start()
    {
        skillCooltimer = GetComponent<SkillCooltimerJ>();
        skillCooltimer.skillData = SkillData;
        
        animator = Owner.GetComponent<Animator>();
    }

    public SkillDataJ FireSkill()
    {
        animator.Play(SkillData.skillAnimation);
        skillCooltimer.StartCoolTimer();
        return SkillData;
    }

    public bool CanFireSkill()
    {
        return skillCooltimer.IsReady;
    }
}
