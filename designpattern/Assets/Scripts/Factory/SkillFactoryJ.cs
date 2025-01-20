using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class SkillFactoryJ
{
    public static List<SkillInstanceJ> CreateSkill(GameObject Owner, List<string> skillNames)
    {
        List<SkillInstanceJ> list = new List<SkillInstanceJ>();
        
        foreach (var skillName in skillNames)
        {
            SkillDataJ skillData = Resources.Load<SkillDataJ>($"SkillData/{skillName}");
            if (skillData.IsUnityNull())
            {
                Debug.LogError($"Skill {skillName} not found");
                continue;
            }
            
            GameObject newObject = new GameObject($"Skill_{skillName}");
            SkillInstanceJ skillInstanceJ = newObject.AddComponent<SkillInstanceJ>();
            
            skillInstanceJ.Owner = Owner;
            skillInstanceJ.SkillData = skillData;
            
            newObject.transform.SetParent(Owner.transform);
            
            list.Add(skillInstanceJ);
        }

        return list;
    }
}