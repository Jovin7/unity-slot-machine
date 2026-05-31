using System.Collections;
using UnityEngine;

public interface IReel
{
    void StartSpin();

    void StopSpin();
    SymbolData[] GetVisibleSymbolData();

    void UpdateSymbolAtRow(int row, SymbolData data);

    SymbolView GetSymbolAtRow(int row);

}
