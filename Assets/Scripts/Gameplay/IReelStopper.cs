using System.Collections;
using UnityEngine;

public interface IReelStopper
{
    bool IsStopping { get; }

    void Tick(float deltaTime);
    void StartStop();

}
