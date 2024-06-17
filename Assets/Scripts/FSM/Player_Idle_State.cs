using System;
using UnityEngine;

/// <summary>
/// Class To Handle The Player Idle State
/// </summary>
public class Player_Idle_State : Player_Base_State
{
    private const string idle_Animation_Name = "Idle";

    public Player_Idle_State(Player_State_Machine playerSM, Player_Component player) : base(nameof(Player_Idle_State), playerSM, player) { }

    public override void OnEnter()
    {
        base.OnEnter();
        //PlayIdleAnimation();
    }
    
    public override void UpdateLogic()
    {
        base.UpdateLogic();
        Debug.Log("Idle State");
        //PlayIdleAnimation();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void AddStateTransitions(string transitionName, State transitionState)
    {
        base.AddStateTransitions(transitionName, transitionState);
    }
}
