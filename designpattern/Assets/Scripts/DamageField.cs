using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageObserver
{
    void OnDamageTaken(DamageField damageField, IDamageable damageable, DamageInfo damageInfo);
}


// 데미지 필드 기본 클래스
public abstract class DamageField : MonoBehaviour
{
    protected float damage;
    protected GameObject owner;
    protected HashSet<IDamageable> damagedTargets = new HashSet<IDamageable>();
    protected bool canDamageMultipleTimes = false;
    protected IDamageObserver observer;
    
    public virtual void Initialize(GameObject owner, float damage, IDamageObserver observer)
    {
        this.owner = owner;
        this.damage = damage;
        this.observer = observer;
        damagedTargets.Clear();
        gameObject.SetActive(true);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == owner) return;

        var damageable = other.GetComponent<IDamageable>();
        if (damageable != null && (canDamageMultipleTimes || !damagedTargets.Contains(damageable)))
        {
            Vector3 hitPoint = other.ClosestPoint(transform.position);
            Vector3 hitNormal = (hitPoint - transform.position).normalized;
            
            var damageInfo = new DamageInfo(damage, hitPoint, hitNormal, owner);
            damageable.TakeDamage(damageInfo);
            damagedTargets.Add(damageable);
            observer?.OnDamageTaken(this, damageable, damageInfo);
        }
    }

    public virtual void Deactivate()
    {
        observer = null;
        gameObject.SetActive(false);
        DamageFieldPool.Instance.ReturnToPool(this);
    }
}
