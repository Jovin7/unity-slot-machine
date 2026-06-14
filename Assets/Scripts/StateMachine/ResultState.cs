using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultState : IGameState
{
    private readonly IGameStateMachine stateMachine;
    private readonly IGameState idleState;
    private readonly IGameState winState;
    private readonly IPaylineService paylineService;
    private readonly IFreeSpinManager freeSpinManager;
    private readonly GameSessionContext sessionContext;

    public ResultState(IGameStateMachine stateMachine,
                       IGameState idleState,
                       IGameState winState,
                       IPaylineService paylineService,
                       IFreeSpinManager freeSpinManager,
                       GameSessionContext sessionContext)
    {
        this.stateMachine = stateMachine;
        this.idleState = idleState;
        this.winState = winState;
        this.paylineService = paylineService;
        this.freeSpinManager = freeSpinManager;
        this.sessionContext = sessionContext;
    }
    public void Enter()
    {

        SpinResult result = paylineService.CheckWin();

        if (result.scatterResult.isScatterTriggered)
        {
            freeSpinManager.AddFreeSpin(result.scatterResult.freeSpins);
        }
        EventBus.Publish(new WinCalculatedEvent(result));

        if (result.winResult.hasWin)
        {
            sessionContext.CurrentWinResult = result.winResult;
            stateMachine.ChangeState(winState);
        }
        else
        {
            stateMachine.ChangeState(idleState);
        }
    }

    public void Exit()
    {
        //GameLogger.State("Result Game state Exit");
    }

    public void Update()
    {

    }
}
