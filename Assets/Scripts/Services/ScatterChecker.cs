using System.Collections;
using UnityEngine;


public class ScatterChecker : IScatterChecker
{
   
    public ScatterResult CheckScatter(SymbolData[,] grid)
    {
        ScatterResult result = new ScatterResult();

        int scatterCount = 0;
        SymbolData scatterSymbol = null;

        for (int i=0;i<grid.GetLength(0);i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                SymbolData symbol = grid[i, j];

                if (symbol.isScatter)
                {
                    scatterCount++;
                    scatterSymbol = symbol;
                }


            }
        }
        result.scatterCount = scatterCount;
        if (scatterCount >= 3)
        {
            result.isScatterTriggered = true;
            result.freeSpins = scatterSymbol.freeSpins;
        }
        return result;
    }
}
