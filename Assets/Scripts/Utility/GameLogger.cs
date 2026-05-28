using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameLogger
{
    public static bool StateLogs = false;
    public static bool ReelLogs = true;
    public static bool WinLogs = true;
    public static bool RNGLogs = true;

    public static void State(string msg)
    {
        if (StateLogs)
            Debug.Log($"<color=yellow>[STATE]</color> {msg}");
    }

    public static void Reel(string msg)
    {
        if (ReelLogs)
            Debug.Log($"<color=cyan>[REEL]</color> {msg}");
    }

    public static void Win(string msg)
    {
        if (WinLogs)
            Debug.Log($"<color=green>[WIN]</color> {msg}");
    }

    public static void RNG(string msg)
    {
        if (RNGLogs)
            Debug.Log($"<color=orange>[RNG]</color> {msg}");
    }
}