using System.Collections;
using UnityEngine;


public class ExpandingWildModifier : IGridModifier
{
    public void ModifyGrid(SymbolData[,] grid)
    {
        int columns = grid.GetLength(0);
        int rows = grid.GetLength(1);

        for(int i=0;i<columns;i++)
        {
            bool hasExpanded = false;
            SymbolData wildSymbol = null;
                
            for(int j=0;j<rows;j++)
            {
                if(grid[i,j].isExpandingWild)
                {
                    hasExpanded = true;
                    wildSymbol = grid[i, j];
                    break;
                }
            }
           
            if(hasExpanded)
            {
                for(int y=0;y<rows;y++)
                {
                    grid[i, y] = wildSymbol;
                }
            }
        }


    }
}
