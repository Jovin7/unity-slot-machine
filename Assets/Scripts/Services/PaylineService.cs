using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PaylineService  : IPaylineService
{
    private IReel[] reels;
    private PaylineDatabase paylineDatabase;
    private ISymbolMatcher symbolMatcher;
    private IGridModifier gridModifier;
    public PaylineService(IReel[] reels, PaylineDatabase paylineDatabase, ISymbolMatcher symbolMatcher, IGridModifier gridModifier)
    {
        this.reels = reels;
        this.paylineDatabase = paylineDatabase;
        this.symbolMatcher = symbolMatcher;
        this.gridModifier = gridModifier;
    }

    public WinResult CheckWin()
    {
        SymbolData[,] grid = BuildGrid(reels);

        ApplyModifiers(grid);

        RefreshUI(grid);

        return EvaluatePaylines(grid);
    }
    private void ApplyModifiers(SymbolData[,] grid)
    {
        gridModifier.ModifyGrid(grid);
    }
    private void RefreshUI(SymbolData[,] grid)
    {
        for (int reel = 0; reel < reels.Length; reel++)
        {
            for (int row = 0; row < 4; row++)
            {
                reels[reel].UpdateSymbolAtRow(row, grid[reel, row]);
            }
        }
    }

    private SymbolData[,] BuildGrid(IReel[] reels)
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
    private WinResult EvaluatePaylines(SymbolData[,] grid)
    {
        WinResult result = new WinResult();

        foreach (var line in paylineDatabase.paylines)
        {
            EvaluateLine(grid, line, result);
        }

        return result;
    }
    private void EvaluateLine(SymbolData[,] grid, Payline line, WinResult result)
    {
        int matchCount = symbolMatcher.GetMatchCount(grid, line, out int multiplier, out SymbolData matchedSymbol);

        if (matchCount < 3)
            return;

        int payout = GetPayout(matchedSymbol, matchCount);

        result.hasWin = true;

        result.winningLines.Add(line);

        result.totalPayout += payout * multiplier;

        AddWinningPositions(line, matchCount, result);

        LogWin(payout, multiplier, result.totalPayout);
    }
    private void AddWinningPositions(Payline line, int matchCount, WinResult result)
    {
        for (int i = 0; i < matchCount; i++)
        {
            result.winningPositions.Add(line.positions[i]);
        }
    }
    private void LogWin(int payout, int multiplier, int totalPayout)
    {
        GameLogger.Win(payout + " " + multiplier + " " + totalPayout);
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
