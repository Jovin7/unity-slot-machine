using System.Collections;
using UnityEngine;


public interface IReelSymbolTracker
{
    void Recycle(SymbolView symbol);

    SymbolData[] GetVisibleData();

    SymbolView GetSymbolAtRow(int row);

    void UpdateSymbolAtRow(int row, SymbolData data);
}
