using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine  : IGameStateMachine
{

    public IGameState currentState { get; private set; }

    public void Initialize(IGameState startingState)
    {
        currentState = startingState;
        currentState.Enter();
    }


    public void ChangeState(IGameState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void Update()
    {
        currentState.Update();
    }

    
}
