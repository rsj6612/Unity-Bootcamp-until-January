using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[State("IdleState")]
public class IdleState : MonoBehaviour, IState, IRecevieInput
{
    public StateMachine Fsm { get; set; }
    
    public Blackboard_Player Blackboard { get; set; }
    
    private bool jumpInputTriggered = false;
    private Vector2 moveInput = Vector2.zero;
    
    public void InitState(IBlackboardBase blackboard)
    {
        Blackboard = blackboard as Blackboard_Player;
    }

    public void Enter()
    {
        PlayercController.Instance.AddInputObserver(Fsm.gameObject, this);
        PlayercController.Instance.AddInputObserver(Fsm.gameObject,  this);
        
        Blackboard.animator.CrossFade("Idles", 0.1f);
        Blackboard.animator.SetFloat("Speed", 0.0f);
    }

    public void UpdateState(float deltaTime)
    {
        if (jumpInputTriggered && Blackboard.rigidbody.velocity.y == 0.0f)
        {
            Fsm.ChangeState<JumpState>();
            return;
        }
        
        if (moveInput.sqrMagnitude > 0)
        {
            Fsm.ChangeState<WalkState>();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            DamageHandler handler = new DamageCalculation_Ver1();
            handler.setNextHandler(new DamageCalculation_Ver1()).
                setNextHandler(new DamageCalculation_Ver1());
            
            DamageFieldJ damageField = (new DamageFieldJBuilder()).
                SetDamage(100).
                SetDuration(2).
                SetRadius(3).
                SetTickInterval(0.1F).
                SetPosition(Fsm.transform.position).
                SetDamageHandler(handler).
                Build();
            
            Debug.Log(damageField.GetCalculatedDamage());
        }
    }

    public void Exit()
    {
        PlayercController.Instance.AddInputObserver(Fsm.gameObject,  null);
        
        jumpInputTriggered = false;
        moveInput = Vector2.zero;
    }

    public void OnTriggered(string action, bool triggerValue)
    {
        if (action == "Jump")
            jumpInputTriggered = triggerValue;
    }

    public void OnReadValue(string action, Vector2 value)
    {
        if (action == "Move")
            moveInput = value;
    }
}