using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageFieldJ : MonoBehaviour
{
    public float damage;
    public float radius;
    public float duration;
    public float tickInterval;

    public DamageHandler handler;

    public float GetCalculatedDamage()
    {
        if (handler != null)
        {
            return handler.HandleDamage(damage);
        }

        return damage;
    }
}

public class DamageFieldJBuilder
{
    private DamageFieldJ damageFieldJ;

    public DamageFieldJBuilder()
    {
        damageFieldJ = new GameObject("").AddComponent<DamageFieldJ>();
        damageFieldJ.AddComponent<SphereCollider>();
    }

    public DamageFieldJBuilder SetDamage(float damage)
    {
        damageFieldJ.damage = damage;
        return this;
    }
    
    public DamageFieldJBuilder SetRadius(float radius)
    {
        damageFieldJ.GetComponent<SphereCollider>().radius = radius;
        damageFieldJ.GetComponent<SphereCollider>().isTrigger = true;
        
        damageFieldJ.radius = radius;
        return this;
    }
    
    public DamageFieldJBuilder SetDuration(float duration)
    {
        damageFieldJ.duration = duration;
        return this;
    }

    public DamageFieldJBuilder SetTickInterval(float tickInterval)
    {
        damageFieldJ.tickInterval = tickInterval;
        return this;
    }
    
    public DamageFieldJBuilder SetPosition(Vector3 pos)
    {
        damageFieldJ.transform.position = pos;
        return this;
    }

    public DamageFieldJBuilder SetDamageHandler(DamageHandler handler)
    { 
        damageFieldJ.handler = handler;
        return this;
    }

    public DamageFieldJ Build()
    {
        return damageFieldJ;
    }
}