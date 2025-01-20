using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BuffPool))]
public class BuffHandler : MonoBehaviour
{
    private BuffPool buffPool;
    private List<IBuff> buffs = new List<IBuff>();

    private void Start()
    {
        buffPool = GetComponent<BuffPool>();
    }

    public IBuff AddBuff<T>() where T : IBuff
    {
        var buff = buffPool.GetBuff<T>();
        buff.ApplyBuff(GetComponent<MonsterStatus>());
        buffs.Add(buff);
        return buff;
    }
    
    public void RemoveBuff(IBuff buff)
    { 
        buff.RemoveBuff(GetComponent<MonsterStatus>());
        buffPool.ReturnBuff(buff);
        buffs.Remove(buff);
    }

    private IBuff buffBurning;
    private IBuff buffFreezing;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            buffBurning = GetComponent<BuffHandler>().AddBuff<Buff_Burning>();
        }
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            buffFreezing = GetComponent<BuffHandler>().AddBuff<Buff_Freezing>();
        }
        
        if (Input.GetKeyDown(KeyCode.N))
        {
            GetComponent<BuffHandler>().RemoveBuff(buffBurning);
        }
        
        if (Input.GetKeyDown(KeyCode.M))
        {
            GetComponent<BuffHandler>().RemoveBuff(buffFreezing);
        }

        
        foreach (var buff in buffs)
        {
            buff.UpdateApplyBuff(GetComponent<MonsterStatus>());
        }
    }
}
