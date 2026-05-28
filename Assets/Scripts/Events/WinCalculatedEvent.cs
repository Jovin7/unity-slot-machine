using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct WinCalculatedEvent : IEvent
{
    public WinResult result;

    public WinCalculatedEvent(WinResult result)
    {
        this.result = result;
    }
   
}
