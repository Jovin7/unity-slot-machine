using System.Collections.Generic;
using UnityEngine;

public class RNGTester : MonoBehaviour
{
    public SymbolDatabase database;

    [ContextMenu("Test RNG")]
    void TestRNG()
    {
        Dictionary<string, int> results =
            new Dictionary<string, int>();

        int totalSpins = 10000;

        // Initialize counts
        foreach (var symbol in database.symbols)
        {
            results[symbol.symbolId] = 0;
        }

        // Run RNG
        for (int i = 0; i < totalSpins; i++)
        {
            SymbolData symbol =
                RNGService.GetWeightedSymbol(database);

            results[symbol.symbolId]++;
        }

        // Print results
        Debug.Log("===== RNG TEST =====");

        foreach (var pair in results)
        {
            float percentage =
                (pair.Value / (float)totalSpins) * 100f;

            Debug.Log(
                pair.Key +
                " = " +
                pair.Value +
                " (" +
                percentage.ToString("F2") +
                "%)");
        }
    }
}