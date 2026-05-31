using System.Collections.Generic;
using UnityEngine;

public class ReelGenerator: IReelGenerator
{
    private SymbolDatabase database;

    private SymbolView symbolPrefab;

    private Transform parent;

    private int visibleSymbols;

    private List<SymbolView> currentSymbols;

    public ReelGenerator(SymbolDatabase database, SymbolView symbolPrefab, Transform parent, int visibleSymbols, List<SymbolView> currentSymbols)
    {
        this.database = database;
        this.symbolPrefab = symbolPrefab;
        this.parent = parent;
        this.visibleSymbols = visibleSymbols;
        this.currentSymbols = currentSymbols;
    }

    public void Generate()
    {
        Clear();

        for (int i = 0; i < visibleSymbols; i++)
        {
            SymbolData randomSymbol = RNGService.GetWeightedSymbol(database);


            SymbolView symbol = Object.Instantiate(symbolPrefab, parent);


            symbol.Setup(randomSymbol);

            currentSymbols.Add(symbol);
        }
    }

    private void Clear()
    {
        foreach (Transform child in parent)
        {
            Object.Destroy(child.gameObject);
        }

        currentSymbols.Clear();
    }

  
}