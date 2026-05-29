using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MatchResult
{
    public int matchCount;

    public SymbolData matchedSymbol;

    public List<Vector2Int> matchedPositions = new List<Vector2Int>();


    public int multiplier = 1;
}
