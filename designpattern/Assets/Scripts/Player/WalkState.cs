﻿using UnityEngine;
using UnityEngine.InputSystem;

[State("WalkState")]
public class WalkState : MonoBehaviour, IState, IRecevieInput
{   public StateMachine Fsm { get; set; }
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
        Blackboard.animator.SetFloat("Speed", 1.0f);
    }

    public void UpdateState(float deltaTime)
    {
        if (jumpInputTriggered && Blackboard.rigidbody.velocity.y == 0.0f)
        {
            Fsm.ChangeState<JumpState>();
            return;
        }
        
        if (0 >= moveInput.sqrMagnitude)
        {
            Fsm.ChangeState<IdleState>();
            return;
        }
        
        Blackboard.rigidbody.velocity = new Vector3(moveInput.x * Blackboard.moveSpeed, Blackboard.rigidbody.velocity.y, moveInput.y * Blackboard.moveSpeed);
    }

    public void Exit()
    {
        PlayercController.Instance.AddInputObserver(Fsm.gameObject,  null);
        PlayercController.Instance.AddInputObserver(Fsm.gameObject,  null);
        
        jumpInputTriggered = false;
        moveInput = Vector2.zero;
    }

    public void OnTriggered(string action, bool triggerValue)
    {
        
    }

    public void OnReadValue(string action, Vector2 value)
    {
        if (action == "Move")
            moveInput = value; 
    }
}