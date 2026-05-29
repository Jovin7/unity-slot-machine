using System.Collections;
using UnityEngine;


    public interface ISymbolMatcher 
    {

        int GetMatchCount(SymbolData[,] grid, Payline line, out int multiplier, out SymbolData matchedSymbol);
    }
