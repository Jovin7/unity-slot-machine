using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RNGService 
{
    public static SymbolData GetWeightedSymbol(SymbolDatabase database)
    {
        int totalWeight = 0;

        foreach (var symbol in database.symbols)
        {
            totalWeight += symbol.weight;
        }

        int random = Random.Range(0, totalWeight);

        foreach (var symbol in database.symbols)
        {
            if (random < symbol.weight)
                return symbol;

            random -= symbol.weight;
        }

        return database.symbols[0];
    }

}
