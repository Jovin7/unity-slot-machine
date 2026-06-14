using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct WinCalculatedEvent : IEvent
{
    public SpinResult result;
    public WinCalculatedEvent(SpinResult result)
    {
        this.result = result;
       
    }
   
}
