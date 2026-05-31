using System.Collections;
using UnityEngine;


    public interface IReelSpinner 
    {
    bool IsSpinning { get; }
    void StartSpin();
    void StopSpin();
    void Tick(float deltaTime);

}
