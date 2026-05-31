using System.Collections.Generic;
using System.Linq;

public class ReelSymbolTracker : IReelSymbolTracker
{
    private readonly List<SymbolView> currentSymbols;

    public ReelSymbolTracker(List<SymbolView> symbols)
    {
        currentSymbols = symbols;
    }

    public void Recycle(SymbolView symbol)
    {
        currentSymbols.RemoveAt(0);

        currentSymbols.Add(symbol);
    }

    public SymbolData[] GetVisibleData()
    {
        return currentSymbols.Select(x => x.GetData()).ToArray();


    }

    public SymbolView GetSymbolAtRow(int row)
    {
        return currentSymbols[row];
    }

    public void UpdateSymbolAtRow(int row, SymbolData data)
    {
        currentSymbols[row].Setup(data);

    }
  
}