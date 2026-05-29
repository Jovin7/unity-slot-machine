using System.Collections;
using UnityEngine;


public class StandardSymbolMatcher : ISymbolMatcher
{

    public int GetMatchCount(SymbolData[,] grid, Payline line , out int multiplier,out SymbolData targetSymbol)
    {
        GameLogger.Win("GetMatchCount");
         multiplier = 0;
         targetSymbol = null;

        for (int i = 0; i < line.positions.Length; i++)
        {
            Vector2Int pos = line.positions[i];

            SymbolData current = grid[pos.x, pos.y];

            if (!current.isWild)
            {
                targetSymbol = current;
                
                GameLogger.Win(targetSymbol.symbolId);
                break;
            }
        }

        if (targetSymbol == null)
        {
            Vector2Int firstPos = line.positions[0];
            targetSymbol = grid[firstPos.x, firstPos.y];
        }

        int count = 0;

        for (int i = 0; i < line.positions.Length; i++)
        {
            Vector2Int pos = line.positions[i];

            SymbolData current = grid[pos.x, pos.y];

            if (current.symbolId == targetSymbol.symbolId || current.isWild)
            {
               // GameLogger.Win($"Payline: {line.lineName}  " + $"Checking Pos: {pos} " + $"Symbol: {current.symbolId}");
                count++;
                if(current.isWild)
                {
                    multiplier += current.multiplier;
                   
                }
               
            }
            else
            {
                break;
            }
        }
        if (multiplier == 0)
        {
            multiplier = 1;
        }   
        return count;
    }


}
