using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinState : IGameState
{

    private readonly ISpinService spinService;
    private readonly IGameStateMachine stateMachine;
    private readonly IGameState nextState;

    public SpinState(ISpinService spinService, IGameStateMachine stateMachine, IGameState nextState)
    {
        this.spinService = spinService;
        this.stateMachine = stateMachine;
        this.nextState = nextState;
    }
    public void Enter()
    {
        //GameLogger.State("Spin Game state Enter");

        spinService.StartSpin();
        EventBus.Subscribe<AllReelsStoppedEvent>(OnSpinStopped);
    }
   

    public void Exit()
    {
        //GameLogger.State("Spin Game state Exit");
        EventBus.UnSubscribe<AllReelsStoppedEvent>(OnSpinStopped);

    }

    public void Update()
    {
        

    }
    private void OnSpinStopped(AllReelsStoppedEvent obj)
    {
        //GameLogger.State("OnSpinStopped");
        stateMachine.ChangeState(nextState);
    }
}
