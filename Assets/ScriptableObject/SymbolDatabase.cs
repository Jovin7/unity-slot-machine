using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SymbolDatabase", menuName = "Slot Machine/Symbol Database")]
public class SymbolDatabase : ScriptableObject
{
    public List<SymbolData> symbols = new List<SymbolData>();
}

[System.Serializable]
public class SymbolData
{
    public string symbolId;

    public Sprite icon;

   // Frequency of the  symbol occuring
    [Range(1, 100)]
    public int weight;

    // Pay range based on the similar symbols

    public int threeMatchPayout;

    public int fourMatchPayout;

    public int fiveMatchPayout;
  
    // Free Spins
    public int freeSpins;
    public int multiplier;
}