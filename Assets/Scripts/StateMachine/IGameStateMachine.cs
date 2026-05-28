using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameStateMachine
{
    IGameState currentState { get; }
    void Initialize(IGameState initialState);
    void ChangeState(IGameState newState);
    void Update();
}
