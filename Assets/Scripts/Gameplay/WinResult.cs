using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinResult
{
    public bool hasWin;

    public int totalPayout;

    public List<Payline> winningLines = new List<Payline>();

    public List<Vector2Int> winningPositions = new List<Vector2Int>();

}
