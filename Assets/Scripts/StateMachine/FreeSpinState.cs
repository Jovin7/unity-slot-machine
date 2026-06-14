using System.Collections;
using UnityEngine;


public class FreeSpinState : IGameState
{
    private readonly IFreeSpinManager freeSpinManager;
    private readonly IGameStateMachine stateMachine;
    private readonly IGameState spinState;

    public FreeSpinState(IFreeSpinManager freeSpinManager, IGameStateMachine stateMachine, IGameState spinState)
    {
        this.freeSpinManager = freeSpinManager;
        this.stateMachine = stateMachine;
        this.spinState = spinState;
    }

    public void Enter()
    {
        GameLogger.State("Idle Game state Enter");
        stateMachine.ChangeState(spinState);
        freeSpinManager.ReduceFreeSpinCount();
    }

    public void Exit()
    {
       
    }

    public void Update()
    {
        
    }
}
