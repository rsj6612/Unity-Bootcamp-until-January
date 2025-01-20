using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageHandler
{
    protected DamageHandler nextHandler;

    public DamageHandler setNextHandler(DamageHandler nextHandler)
    {
        this.nextHandler = nextHandler;
        return this.nextHandler;
    }

    public abstract float HandleDamage(float damage);
}

public class DamageCalculation_Ver1 : DamageHandler
{
    public override float HandleDamage(float damage)
    {
        damage += 100.0f;
        return nextHandler?.HandleDamage(damage) ?? damage;
    }
}

public class DamageCalculation_Ver2 : DamageHandler
{
    public override float HandleDamage(float damage)
    {
        damage *= 2.0f;
        return nextHandler?.HandleDamage(damage) ?? damage;
    }
}

public class DamageCalculation_Ver3 : DamageHandler
{
    public override float HandleDamage(float damage)
    {
        damage *= 0.3f;
        return nextHandler?.HandleDamage(damage) ?? damage;
    }
}