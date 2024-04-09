using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    private readonly int FallHash = Animator.StringToHash("Fall");
    private const float CrossfadeDuration = 0.1f;
    private Vector3 momentum;
    public PlayerFallState(PlayerStateMachine stateMachine) : base(stateMachine) {}

    public override void Enter()
    {
        momentum = stateMachine.Controller.velocity;
        momentum.y = 0f;
        stateMachine.Animator.CrossFadeInFixedTime(FallHash, CrossfadeDuration);    
    }

    public override void Tick(float deltaTime)
    {
       Move(momentum, deltaTime);

       if (stateMachine.Controller.isGrounded)
       {
            ReturnToLocomotion();
       }


       FaceTarget();
    }

    public override void Exit()
    {
        
    }

   
}
