using System.Collections;
using UnityEngine;


public interface IScatterChecker
{

    ScatterResult CheckScatter(SymbolData[,] grid);
}

public class ScatterResult
{
    public bool isScatterTriggered;
    public int scatterCount;
    public int freeSpins;

}