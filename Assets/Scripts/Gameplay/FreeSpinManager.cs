using System.Collections;
using UnityEngine;

public class FreeSpinManager: IFreeSpinManager
{

    public int RemainingSpins { get; private set; }

    public bool IsFreeSpinAvailable => RemainingSpins > 0;


    public void AddFreeSpin(int spinCount)
    {
        RemainingSpins += spinCount;
        EventBus.Publish(new FreeSpinUpdatedEvent(RemainingSpins));

    }
    public void ReduceFreeSpinCount()
    {
        RemainingSpins--;
        EventBus.Publish(new FreeSpinUpdatedEvent(RemainingSpins));

    }
}
