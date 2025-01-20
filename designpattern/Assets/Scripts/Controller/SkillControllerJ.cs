using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillControllerJ : MonoBehaviour
{
    private List<SkillInstanceJ> skillInstances = new List<SkillInstanceJ>();
    [SerializeField] List<string>       skillNames = new List<string>();

    private void Start()
    {
        skillInstances = SkillFactoryJ.CreateSkill(gameObject, skillNames);
    }

    public SkillDataJ FireSkill(int skillIndex)
    {
        var skillInstance = skillInstances.Count > skillIndex ? skillInstances[skillIndex] : null;
        if (skillInstance && skillInstance.CanFireSkill())
        {
            return skillInstance.FireSkill();
        }

        return null;
    }

    public (int, float) GetAvailableSkillAndDistance()
    {
        int bestIndex = -1;
        float minDistance = float.MaxValue;
        var count = skillInstances.Count;
    
        for (int i = 0; i < count; i++)
        {
            var skill = skillInstances[i];
            if (!skill.CanFireSkill()) continue;
        
            var distance = skill.SkillData.skillEnableDistance;
            if (distance < minDistance)
            {
                minDistance = distance;
                bestIndex = i;
            }
        }

        return (bestIndex, minDistance);
    }
}
