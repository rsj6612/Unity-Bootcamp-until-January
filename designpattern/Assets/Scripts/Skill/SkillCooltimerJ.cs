using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class SkillCooltimerJ : MonoBehaviour
{
    public SkillDataJ skillData;
    private float remainDuration;

    public bool IsReady => 0 >= remainDuration;

    public float RemainDuration => remainDuration;

    public void StartCoolTimer()
    {
        CoolTimeProcess();
    }

    async void CoolTimeProcess()
    {
        remainDuration = skillData.skillCooltime;
        
        while (remainDuration > 0.0f)
        {
            remainDuration -= Time.deltaTime;
            await UniTask.Yield();
        }
    }
}
