using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "Game/Skill Data")]
public class SkillData : ScriptableObject
{
    public string skillName;
    public float cooltime;
    public float damage;
    public float range;
}


// UniTask 방식
public class CoolTimer 
{
    public event System.Action onComplete;
    private CancellationTokenSource cts;
    public bool IsCompleted => cts == null;
    private bool isDisposed;

    public async UniTaskVoid StartTimer(float duration) 
    {
        // 이전 타이머가 있다면 취소
        cts?.Cancel();
        cts?.Dispose();
        
        cts = new CancellationTokenSource();
        
        try 
        {
            await UniTask.Delay(TimeSpan.FromSeconds(duration), cancellationToken: cts.Token);
            onComplete?.Invoke();
        }
        catch (OperationCanceledException) 
        {
            // 타이머 취소 처리
        }
        finally
        {
            // 타이머 완료 후 정리
            cts?.Dispose();
            cts = null;
        }
    }
    
    public void Cancel()
    {
        cts?.Cancel();
        cts?.Dispose();
        cts = null;
    }

    public void Dispose()
    {
        if (isDisposed) return;
        
        cts?.Cancel();
        cts?.Dispose();
        cts = null;
        isDisposed = true;
    }
}

// 스킬 인스턴스 기본 클래스
public class SkillInstance : MonoBehaviour, IDamageObserver
{
    public SkillData data;
    protected Entity owner;
    protected CoolTimer coolTimer;

    public void Initialize(Entity owner, SkillData data, IDamageObserver damageObserver)
    {
        this.data = data;
        this.owner = owner;
        coolTimer = new CoolTimer();
    }

    public void UseSkill()
    {
        _ = coolTimer.StartTimer(data.cooltime);
    }

    public bool IsInRange()
    {
        if (owner == null) return false;
        if (owner.currentTarget == null) return false;
        
        return (owner.transform.position - owner.currentTarget.transform.position).sqrMagnitude < Mathf.Pow(data.range, 2);
    }

    public bool IsCompletedCoolTime()
    {
        return coolTimer.IsCompleted;
    }

    public void OnNotifyHit(string damageFieldName)
    {
        DamageField dm = DamageFieldPool.Instance.GetDamageField(damageFieldName, transform.position, transform.rotation);
        dm.Initialize(this.gameObject, data.damage, this);
    }

    public void OnDamageTaken(DamageField damageField, IDamageable damageable, DamageInfo damageInfo)
    {
       owner?.OnDamageTaken(damageField, damageable, damageInfo);
    }
}