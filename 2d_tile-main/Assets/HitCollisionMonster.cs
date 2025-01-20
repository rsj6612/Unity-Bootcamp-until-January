using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollisionMonster : MonoBehaviour
{
    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     // Rigidbody2D rb = other.GetComponent<hitCollision>().parentRigidbody;
    //     //
    //     // Vector3 backPosition =  rb.transform.position - transform.position;
    //     // backPosition.Normalize();
    //     // backPosition.x *= 3;
    //     // rb.AddForce(backPosition * 800, ForceMode2D.Force);   
    // }
    void OnTriggerEnter2D(Collider2D other)
    {
        // DamageField와 충돌한 경우에만 처리
        if (other.gameObject.layer == LayerMask.NameToLayer("DamageField"))
        {
            // 피격 판정 처리 (여기서 TakeDamage는 호출하지 않음)
            // 데미지는 DamageField에서 처리되므로 추가 작업은 필요 없음
        }
    }
}