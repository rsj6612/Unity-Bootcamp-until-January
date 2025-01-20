using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageField : MonoBehaviour
{
    public string MyOwnerTag; // DamageField 소유자 (플레이어 등)

    private void OnTriggerEnter2D(Collider2D other)
    {
        // DamageField가 소유자와 충돌하지 않도록 필터링
        if (!other.CompareTag(MyOwnerTag))
        {
            // 몬스터 레이어 확인
            if (other.gameObject.layer == LayerMask.NameToLayer("Monster"))
            {
                // Monster 컴포넌트 가져오기
                Monster monster = other.GetComponent<Monster>();
                if (monster != null)
                {
                    monster.TakeDamage(1); // 데미지 1 적용
                }
            }
        }
    }
}