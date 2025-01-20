using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플라이 웨이트 패턴 디자인 패턴
[CreateAssetMenu(fileName = "SkillData", menuName = "Game/Skill Data")]
public class SkillDataJ : ScriptableObject
{
    public string skillName;
    public string skillIcon;
    public string skillAnimation;

    public float skillDuration;
    public float skillCooltime;
    public float skillEnableDistance;
}