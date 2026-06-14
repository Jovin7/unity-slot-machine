using System.Collections;
using UnityEngine;


public interface IFreeSpinManager
{
    int RemainingSpins { get; }
    bool IsFreeSpinAvailable { get; }

    void AddFreeSpin(int spinCount);
    void ReduceFreeSpinCount();
}
