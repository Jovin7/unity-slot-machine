using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WinPresentationService : IWinPresentationService
{
    private readonly ReelController[] reels;
    private readonly PaylineRenderer paylineRenderer;
    
    public WinPresentationService(ReelController[] reels, PaylineRenderer paylineRenderer)
    {
        this.reels = reels;
        this.paylineRenderer = paylineRenderer;
    }
    public void HideWinEffects(WinResult result)
    {
       // GameLogger.State("Stop Win Animation");

        foreach (var pos in result.winningPositions)
        {
            ReelController reel = reels[pos.x];
            SymbolView symbol = reel.GetSymbolAtRow(pos.y);
            symbol.StopWinAnimation();
        }
        paylineRenderer.gameObject.SetActive(false);
    }

    public void ShowWinEffects(WinResult result)
    {
      //  GameLogger.State("Play Win Animation");
        foreach (var pos in result.winningPositions)
        {
            ReelController reel = reels[pos.x];
            SymbolView symbol = reel.GetSymbolAtRow(pos.y);
            symbol.PlayWinAnimation();
        }
        List<Vector3> points = new List<Vector3>();


        foreach (var pos in result.winningPositions)
        {
            ReelController reel = reels[pos.x];
            SymbolView symbol =  reel.GetSymbolAtRow(pos.y);
            points.Add(symbol.transform.position);
        }
        paylineRenderer.gameObject.SetActive(true);
        paylineRenderer.DrawLine(points);
    }

}
