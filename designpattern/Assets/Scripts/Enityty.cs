using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour, IDamageable, IDamageObserver
{
    // 상태 관리
    private StateMachine stateMachine;
    
    // 타겟팅
    [Header("Target")]
    public Transform currentTarget;
    public LayerMask targetLayer;

    protected virtual void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        //stateMachine.Run();
    }

    protected virtual void Update()
    {
        // stateMachine.UpdateState();
    }

    public void TakeDamage(DamageInfo damageInfo)
    {
        
    }
    
    public void OnDamageTaken(DamageField damageField, IDamageable damageable, DamageInfo damageInfo)
    {
       
    }
}

