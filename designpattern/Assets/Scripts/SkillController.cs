using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    public List<SkillData> skills = new();
    public SkillInstance activeSkill;
    public Dictionary<string, SkillInstance> SkillInstances = new();
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (var skillData in skills)
        {
            var skillInstance = SkillPoolManager.Instance.GetSkillInstance(skillData.skillName);
            SkillInstances.Add(skillData.skillName, skillInstance);
        }
    }

    public void UseSkill(string skillName)
    {
        if (SkillInstances.TryGetValue(skillName, out var skillInstance))
        {
            skillInstance.UseSkill();
            activeSkill = skillInstance;
        }
    }
    
    public void OnNotifyHit(string damageFieldName)
    {
        if (activeSkill != null)
        {
            activeSkill.OnNotifyHit(damageFieldName);
        }
    }
}
