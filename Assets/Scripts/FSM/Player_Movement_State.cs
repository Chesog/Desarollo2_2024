using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement_State : Player_Base_State
{ 
    private const string jump_Animation_Name = "VelocityY";
    [SerializeField] public Vector3 movement;
    public Player_Movement_State(Player_State_Machine playerSM, Player_Component player) : base(nameof(Player_Movement_State), playerSM, player) { }
    public override void OnEnter()
    {
        base.OnEnter();
        player.OnPlayerMove += OnPlayerMove;
    }

    private void OnPlayerMove(Vector2 move)
    {
        movement = new Vector3(move.x, 0, move.y);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (movement == Vector3.zero)
            state_Machine.SetState(base.transitions[nameof(Player_Idle_State)]);

        if (movement.x > 0)
            movement.x -= Time.deltaTime;
        else if (movement.x < 0)
            movement.x = 0;
        
        if (movement.y > 0)
            movement.y -= Time.deltaTime;
        else if (movement.y < 0)
            movement.y = 0;
        
        if (movement.z > 0)
            movement.z -= Time.deltaTime;
        else if (movement.z < 0)
            movement.z = 0;
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        player.rigidbody.velocity = movement;
    }

    public override void AddStateTransitions(string transitionName, State transitionState)
    {
        base.AddStateTransitions(transitionName, transitionState);
    }


    public override void OnExit()
    {
        base.OnExit();
    }
}
