using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 지속 데미지 필드 (독 구름 등)
public class DoTDamageField : DamageField
{
    private float duration = 3f;
    private float tickInterval = 0.5f;
    private float currentTime = 0f;
    private float tickTime = 0f;

    public override void Initialize(GameObject owner, float damage, IDamageObserver damageObserver)
    {
        base.Initialize(owner, damage, damageObserver);
        currentTime = 0f;
        tickTime = 0f;
        canDamageMultipleTimes = true; // 여러 번 데미지
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        tickTime += Time.deltaTime;

        if (tickTime >= tickInterval)
        {
            tickTime = 0f;
            damagedTargets.Clear(); // 틱마다 데미지 대상 초기화
        }

        if (currentTime >= duration)
        {
            Deactivate();
        }
    }
}
