using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public struct DamageFieldData
{
    public float distance;
}

public class CharController : MonoBehaviour
{
    private const float jumpTestValue = 0.3f;
    private static readonly int Speed1 = Animator.StringToHash("Speed");
    private static readonly int Ground = Animator.StringToHash("Ground");
    [SerializeField] private float Speed = 5.0f;
    [SerializeField] private float JumpSpeed = 15.0f;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private float CameraSpeed = 4.0f;
    [SerializeField] private float MaxDistence = 4.0f;
    
    private Vector3 cameraOffset;
    
    InputAction Move_Input;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private InputAction Jump_Input;

    public List<CButton> _buttons; 
    public List<DamageField> _damageFields;
    public List<DamageFieldData> _damageFieldDatas;
    
    public Canvas _canvas;
    public HpBar _hpBar;
    public Camera ui_camera;
    public Transform hpPosition;
    
    [NonSerialized]public int Grounded = 0;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        UnityEngine.InputSystem.PlayerInput Input = GetComponent<UnityEngine.InputSystem.PlayerInput>();
        Move_Input = Input.actions["Move"];
        Jump_Input = Input.actions["Jump"];

        cameraOffset = _mainCamera.transform.position - transform.position;

        // 버튼에 고유한 동작 추가
        if (_buttons.Count >= 3)
        {
            _buttons[0].AddListener(FireSkill);
            _buttons[1].AddListener(FireStorm);
            _buttons[2].AddListener(BlueStorm);
        }
        
        GameObject go = Instantiate(_hpBar.gameObject, _canvas.transform);
        go.GetComponent<HpBar>().UpdateOwner(hpPosition, ui_camera);
    }

    private bool canMove = true;

    void AttackDamageField(int index)
    {
        GameObject go = Instantiate(_damageFields[index].gameObject);
        go.GetComponent<DamageField>().MyOwnerTag = "Player";
        go.transform.position = transform.position + transform.right * _damageFieldDatas[index].distance;
        Destroy(go, 2.0f);
    }
    
    void CanMove(int bMove)
    {
        canMove = bMove == 1;
    }
    
    void FireSkill()
    {
        _animator.Rebind();
        _animator.Play("Attack1");
    }

    void FireStorm()
    {
        _animator.Rebind();
        _animator.Play("Attack2");
    }

    void BlueStorm()
    {
        _animator.Rebind();
        _animator.Play("Attack3");
    }


    void FixedUpdate()
    {
        Vector2 moveValue = Move_Input.ReadValue<Vector2>();

        if (!canMove)
        {
            moveValue = Vector2.zero;
        }
        
        if (moveValue.x != 0)
            _spriteRenderer.flipX = moveValue.x < 0;
        
        _animator.SetFloat(Speed1, Mathf.Abs(moveValue.x));
        
        if (moveValue.x == 0)
            _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
        
        transform.position += new Vector3(moveValue.x * Speed * Time.deltaTime, 0, 0);
        
    }

    void Update()
    {
        if (Jump_Input.triggered && Grounded >= 1)
        {
            _rigidbody.AddForce(Vector2.up * JumpSpeed, ForceMode2D.Impulse);
            _animator.Play("Alchemist_Jump");
        }
    }
    
    private void LateUpdate()
    {
        var CharPosition = transform.position + cameraOffset;
        float speed = CameraSpeed;

        Vector3 newPosition = Vector3.zero;
        
        if (Vector3.Distance(CharPosition, _mainCamera.transform.position) >= MaxDistence)
        {
            Vector3 Gap = ((_mainCamera.transform.position) - CharPosition).normalized * MaxDistence;
            newPosition = CharPosition + Gap;
        }
        else
        {
            newPosition = Vector3.MoveTowards(_mainCamera.transform.position, 
                CharPosition, 
                speed * Time.deltaTime);
        }

        _mainCamera.transform.position = newPosition;
    }
}
