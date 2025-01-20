using UnityEngine;

// 데미지 처리를 위한 인터페이스
public interface IDamageable
{
    void TakeDamage(DamageInfo damageInfo);
}

// 데미지 정보 구조체
public struct DamageInfo
{
    public float amount;
    public Vector3 hitPoint;
    public Vector3 hitNormal;
    public GameObject attacker;

    public DamageInfo(float amount, Vector3 hitPoint, Vector3 hitNormal, GameObject attacker)
    {
        this.amount = amount;
        this.hitPoint = hitPoint;
        this.hitNormal = hitNormal;
        this.attacker = attacker;
    }
}
