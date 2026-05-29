using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : IGameState
{
    private readonly IGameStateMachine stateMachine;
    private readonly IGameState idleState;
    private readonly IWinPresentationService winPresentationService;
    private WinResult currentResult;

    private float timer;
    private float duration = 2f;

   
    public WinState(IGameStateMachine stateMachine, IGameState idleState, IWinPresentationService winPresentationService)
    {
        this.stateMachine = stateMachine;
        this.idleState = idleState;
        this.winPresentationService = winPresentationService;
    }
    public void SetResult(WinResult result)
    {
        currentResult = result;
    }
    public void Enter()
    {
        //GameLogger.State("Win Game state Enter");
        timer = 0f;
      
        winPresentationService.ShowWinEffects(currentResult);


     
    }
    
    public void Exit()
    {
        //GameLogger.State("Win Game state Exit");
        winPresentationService.HideWinEffects(currentResult);

    }

    public void Update()
    {
        timer += Time.deltaTime;

        if (timer >= duration)
        {
            stateMachine.ChangeState(idleState);
        }

    }
   
}
