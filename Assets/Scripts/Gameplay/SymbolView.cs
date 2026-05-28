using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SymbolView : MonoBehaviour
{
    public Image icon;

    private SymbolData data;
    private bool isAnimating;

    public void Setup(SymbolData symbolData)
    {
        data = symbolData;
        icon.sprite = data.icon;
    }

    public SymbolData GetData()
    {
        return data;
    }
    public void PlayWinAnimation()
    {
        isAnimating = true;
    }

    public void StopWinAnimation()
    {
        isAnimating = false;

        transform.localScale = Vector3.one;
    }

    void Update()
    {
        if (!isAnimating)
            return;

        float scale =
            1f + Mathf.Sin(Time.time * 8f) * 0.1f;

        transform.localScale =
            Vector3.one * scale;
    }
}
