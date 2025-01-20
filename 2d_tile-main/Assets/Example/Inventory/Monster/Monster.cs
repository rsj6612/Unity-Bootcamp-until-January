using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Rigidbody2D _rigidbody;

    public float Speed = 5.0f;
    public int switchCount = 0;
    private int moveCount = 0;

    public Vector2 _direction;

    private LayerMask playerlayerMask;

    // 체력 관련 변수
    public int MaxHealth = 3; // 최대 체력
    private int currentHealth; // 현재 체력
    public Slider healthBar; // 체력바 (Unity UI Slider)

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        playerlayerMask = LayerMask.NameToLayer("Player");

        // 체력 초기화
        currentHealth = MaxHealth;

        // 체력바 초기화
        if (healthBar != null)
        {
            healthBar.maxValue = MaxHealth;
            healthBar.value = currentHealth;
        }
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        transform.position += new Vector3(_direction.x * Speed * Time.deltaTime, 0, 0);

        moveCount++;

        if (moveCount >= switchCount)
        {
            _direction *= -1;
            _spriteRenderer.flipX = _direction.x < 0;
            moveCount = 0;
        }
    }

    // 데미지를 처리하는 메서드
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        _animator.Rebind();
        _animator.Play("Hurt");
        // 체력바 업데이트
        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }

        // 체력이 0 이하일 때 몬스터 죽음 처리
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // 몬스터 죽음 처리
    void Die()
    {
        // 애니메이션, 파괴 처리
        _animator.Rebind();
        _animator.Play("Death");
        Destroy(gameObject, 1.0f); // 1초 후 객체 파괴
    }
}