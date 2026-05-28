using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class SpinService : ISpinService
{
    public readonly ReelController[] reels;

    public SpinService(ReelController[] reels)
    {
        this.reels = reels;
    }
    public void StartSpin()
    {
      
        foreach (var reel in reels)
        { 
            reel.StartSpin();
        }
    }
}
