using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player_Component : MonoBehaviour
{
    [SerializeField] public Rigidbody rigidbody;
    [SerializeField] public float jumpForce;
    [SerializeField] public float speed;
    [SerializeField] private Player_State_Machine _stateMachine;

    private Player_Idle_State idleState;
    private Player_Movement_State moveState;
    private Player_Jump_State jumpState;

    public UnityAction<Vector2> OnPlayerMove;
    public UnityAction<bool> OnPlayerJump;

    public void OnEnable()
    {
        idleState = new Player_Idle_State(_stateMachine, this);
        moveState = new Player_Movement_State(_stateMachine, this);
        jumpState = new Player_Jump_State(_stateMachine, this);

        idleState.AddStateTransitions(nameof(Player_Movement_State), moveState);
        idleState.AddStateTransitions(nameof(Player_Jump_State), jumpState);

        moveState.AddStateTransitions(nameof(Player_Idle_State), idleState);
        moveState.AddStateTransitions(nameof(Player_Jump_State), jumpState);

        jumpState.AddStateTransitions(nameof(Player_Movement_State), moveState);
        jumpState.AddStateTransitions(nameof(Player_Idle_State), idleState);
    }


    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (x != 0 && y != 0)
        {
            _stateMachine.SetState(moveState);
            Vector2 moveVec = new Vector2(x, y);
            OnPlayerMove.Invoke(moveVec);
        }

        if (Input.GetButton("Jump"))
        {
            _stateMachine.SetState(jumpState);
            
            if (_stateMachine.GetCurrentState() != jumpState)
                OnPlayerJump.Invoke(Input.GetButton("Jump"));
            else
                _stateMachine.SetState(jumpState);
        }
    }
}