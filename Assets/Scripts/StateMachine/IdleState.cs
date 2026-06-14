using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IGameState
{
    private readonly IFreeSpinManager freeSpinManager;
    private readonly IGameStateMachine stateMachine;
    private IGameState freeSpinState;

    public IdleState(IFreeSpinManager freeSpinManager, IGameStateMachine stateMachine)
    {
        this.freeSpinManager = freeSpinManager;
        this.stateMachine = stateMachine;
    }
    public void InjectFreeSpinState(IGameState freeSpinState)
    {
        this.freeSpinState = freeSpinState;
    }
    public void Enter()
    {
        GameLogger.State("Idle Game state Enter");
        if (freeSpinManager.IsFreeSpinAvailable)
        {
            stateMachine.ChangeState(freeSpinState);
            return;
        }
           

        EventBus.Publish(new SpinAvailabilityChangedEvent());
    }

    public void Exit()
    {
       // GameLogger.State("Idle Game state Exit");

    }

    public void Update()
    {
      //  GameLogger.State("Idle Game state Update");

    }
  
}
