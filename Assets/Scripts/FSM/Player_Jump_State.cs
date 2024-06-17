using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Jump_State : Player_Base_State
{ 
    public Player_Jump_State(State_Machine state_Machine, Player_Component player) : base(nameof(Player_Jump_State), state_Machine, player) { }
    public override void OnEnter()
    {
        base.OnEnter();
        player.rigidbody.AddForce(Vector3.up * player.jumpForce, ForceMode.Impulse);
        PlayJumpAnimation();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (isGrounded() && player.rigidbody.velocity.y == 0)
            base.state_Machine.SetState(base.transitions[nameof(Player_Idle_State)]);

    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }

    /// <summary>
    /// Play The Jump Animation For The Player
    /// </summary>
    public void PlayJumpAnimation()
    {
        // player.anim.SetFloat(jump_Animation_Name, player.rigidbody.velocity.y);
    }

    public bool isGrounded()
    {
        // return Physics.Raycast(player.feet_Pivot.position, Vector3.down, out var hit, player.maxDistance) && hit.distance <= player.minJumpDistance;
        return true;
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
