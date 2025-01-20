using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IBuff
{
    void ApplyBuff(MonsterStatus status);
    
    void UpdateApplyBuff(MonsterStatus status);
    
    void RemoveBuff(MonsterStatus status);
}

public class Buff_Burning : IBuff
{
    public void ApplyBuff(MonsterStatus status)
    {
        
    }

    public void UpdateApplyBuff(MonsterStatus status)
    {
        status.Hp -= 1;
    }

    public void RemoveBuff(MonsterStatus status)
    {
    }
}


public class Buff_Freezing : IBuff
{
    public void ApplyBuff(MonsterStatus status)
    {
        status.Speed = 0;
    }

    public void UpdateApplyBuff(MonsterStatus status)
    {
    }

    public void RemoveBuff(MonsterStatus status)
    {
        status.Speed = 1;
    }
}
