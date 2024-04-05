using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public InputReader InputReader {get; private set;}
    [field: SerializeField] public CharacterController Controller {get; private set;}
    [field: SerializeField] public Animator Animator {get; private set;}
    [field: SerializeField] public Targeter Targeter {get; private set;}
    [field: SerializeField] public ForceReceiver ForceReceiver {get; private set;}
    [field: SerializeField] public WeaponDamage Weapon {get; private set;}
    [field: SerializeField] public Health Health {get; private set;}
    [field: SerializeField] public float FreeLookMovementSpeed {get; private set;}
    [field: SerializeField] public float TargettingMovementSpeed {get; private set;}
    [field: SerializeField] public float RotationDumping {get; private set;}
    [field: SerializeField] public Attack[] Attacks{get; private set;}
    public Transform MainCameraTransform {get; private set;}
    void Start()
    {
        MainCameraTransform = Camera.main.transform;
        SwitchState(new PlayerFreeLookState(this));
    }

    private void OnEnable()
    {
        Health.OnTakeDamage += HandleTakeDamage;
        Health.OnDie += HandleDie;
    }

    private void OnDisable()    
    {
        Health.OnTakeDamage -= HandleTakeDamage;
        Health.OnDie -= HandleDie;
    }

    private void HandleTakeDamage()
    {
        SwitchState(new PlayerImpactState(this));
    }

    private void HandleDie()
    {
        SwitchState(new PlayerDeathState(this));
    }

}
