using System.Collections;
using UnityEngine;


public struct FreeSpinUpdatedEvent : IEvent
{

    public int remainingSpin;

    public FreeSpinUpdatedEvent(int remainingSpin)
    {
        this.remainingSpin = remainingSpin;
    }
}