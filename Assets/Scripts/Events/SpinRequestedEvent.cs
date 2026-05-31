using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SpinRequestedEvent  : IEvent
{
    public int betAmount;

   public SpinRequestedEvent (int betAmount)
    {
        this.betAmount = betAmount;
    }
}
