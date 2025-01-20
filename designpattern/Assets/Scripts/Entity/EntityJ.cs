using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[
    RequireComponent(typeof(Rigidbody)), 
    RequireComponent(typeof(CapsuleCollider)),
    RequireComponent(typeof(StateMachine)),
    RequireComponent(typeof(Animator)),
    RequireComponent(typeof(CustomTag)),
    RequireComponent(typeof(SkillControllerJ)),
]
public abstract class EntityJ : MonoBehaviour
{
    protected StateMachine stateMachine;
    protected Rigidbody rigidbody;
    
    protected virtual StaterType EnityStaterType => StaterType.None;

    void Awake()
    {
        stateMachine = GetComponent<StateMachine>();
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    protected virtual void Start()
    {
        stateMachine.Run(EnityStaterType);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine?.UpdateState();
    }
}
