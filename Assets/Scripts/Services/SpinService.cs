using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class SpinService : ISpinService
{
    public readonly IReel[] reels;

    public SpinService(IReel[] reels)
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
