using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PaylineService  : IPaylineService
{
    private ReelController[] reels;
    private PaylineDatabase paylineDatabase;
    private ISymbolMatcher symbolMatcher;
    public PaylineService(ReelController[] reels, PaylineDatabase paylineDatabase, ISymbolMatcher symbolMatcher)
    {
        this.reels = reels;
        this.paylineDatabase = paylineDatabase;
        this.symbolMatcher = symbolMatcher;
    }

    public WinResult CheckWin()
    {
        WinResult result = new WinResult();
        SymbolData[,] grid = BuildGrid(reels);
        
        foreach (var line in paylineDatabase.paylines)
        {
            Vector2Int firstPos = line.positions[0];

            SymbolData symbol = grid[firstPos.x, firstPos.y];
          
            int matchCount = symbolMatcher.GetMatchCount(grid, line, out int multiplier, out SymbolData matchedSymbol);

            if (matchCount >= 3)
            {
                
                result.hasWin = true;

                result.winningLines.Add(line);
              
                int payout = GetPayout(matchedSymbol, matchCount);

                result.totalPayout += (payout * multiplier);

                for (int i = 0; i < matchCount; i++)
                {
                    result.winningPositions.Add(line.positions[i]);

                }
                //GameLogger.Win(symbol.symbolId + " matched " + matchCount + " = payout " + payout);
                GameLogger.Win(payout +"            "+multiplier +"       "+result.totalPayout.ToString());
            }
           
        }
        return result;
    }
    private SymbolData[,] BuildGrid(ReelController[] reels)
    {
        SymbolData[,] grid = new SymbolData[5, 4];

        for(int i =0; i< reels.Length; i++)
        {
            SymbolData[] visible = reels[i].GetVisibleSymbolData();
            for(int j=0;j< visible.Length; j++)
            {
                grid[i, j] = visible[j];

            }
        }
            
        return grid;
    }
  

    private int GetPayout(SymbolData symbol,int matchCount)
    {
        switch (matchCount)
        {
            case 3:
                return symbol.threeMatchPayout;

            case 4:
                return symbol.fourMatchPayout;

            case 5:
                return symbol.fiveMatchPayout;
        }

        return 0;
    }
}

[System.Serializable]
public class Payline
{
    public string lineName;

    public Vector2Int[] positions;
}
