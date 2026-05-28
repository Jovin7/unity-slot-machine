using System.Collections.Generic;
using UnityEngine;

public class PaylineRenderer : MonoBehaviour
{
    public LineRenderer lineRenderer;
    private void Awake()
    {
        lineRenderer.sortingOrder = 100;
    }
    public void DrawLine(
        List<Vector3> points)
    {
        lineRenderer.positionCount =
            points.Count;

        lineRenderer.SetPositions(
            points.ToArray());
    }

    public void Clear()
    {
        lineRenderer.positionCount = 0;
    }
}