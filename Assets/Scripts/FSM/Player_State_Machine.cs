using UnityEngine;

/// <summary>
/// Class To Handle The Player State Machine
/// </summary>
public class Player_State_Machine : State_Machine
{
    [SerializeField] public Player_Component player;

    [SerializeField] private Player_Idle_State idleState;
    [SerializeField] private Player_Movement_State moveState;
    [SerializeField] private Player_Jump_State jumpState;

    protected override void OnEnable()
    {
        idleState = new Player_Idle_State(this, player);
        moveState = new Player_Movement_State(this, player);
        jumpState = new Player_Jump_State(this, player);

        idleState.AddStateTransitions(nameof(Player_Movement_State), moveState);
        idleState.AddStateTransitions(nameof(Player_Jump_State), jumpState);

        moveState.AddStateTransitions(nameof(Player_Idle_State), idleState);
        moveState.AddStateTransitions(nameof(Player_Jump_State), jumpState);

        jumpState.AddStateTransitions(nameof(Player_Movement_State), moveState);
        jumpState.AddStateTransitions(nameof(Player_Idle_State), idleState);

        base.OnEnable();
    }
    
    protected override State GetInitialState()
    {
        return idleState;

    }
}
