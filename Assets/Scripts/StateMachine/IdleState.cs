using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IGameState
{
   
    public void Enter()
    {
       // GameLogger.State("Idle Game state Enter");

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
