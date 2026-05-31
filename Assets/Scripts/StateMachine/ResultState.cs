using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultState : IGameState
{
    private readonly IGameStateMachine stateMachine;
    private readonly IGameState idleState;
    private readonly IGameState winState;
    private readonly IPaylineService paylineService;
    private readonly GameSessionContext sessionContext;

    public ResultState(IGameStateMachine stateMachine, IGameState idleState, IGameState winState, IPaylineService paylineService, GameSessionContext sessionContext)
    {
        this.stateMachine = stateMachine;
        this.idleState = idleState;
        this.winState = winState;
        this.paylineService = paylineService;
        this.sessionContext = sessionContext;
    }
    public void Enter()
    {
        //GameLogger.State("Result Game state Enter");

        WinResult result = paylineService.CheckWin();

        EventBus.Publish(new WinCalculatedEvent(result));

        if (result.hasWin)
        {
           // ((WinState)winState).SetResult(result);
            sessionContext.CurrentWinResult = result;
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
