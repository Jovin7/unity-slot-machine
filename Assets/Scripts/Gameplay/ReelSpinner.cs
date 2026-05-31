using System;
using System.Collections;
using UnityEngine;


public class ReelSpinner : IReelSpinner
{
    private RectTransform contentParent;
    private float spinSpeed;
    private float symbolHeight;
    private Action recycleAction;

    public ReelSpinner(RectTransform contentParent, float spinSpeed, float symbolHeight, Action recycleAction)
    {
        this.contentParent = contentParent;
        this.spinSpeed = spinSpeed;
        this.symbolHeight = symbolHeight;
        this.recycleAction = recycleAction;
      
    }

    public bool IsSpinning { get; private set; }

    public void StartSpin()
    {
        IsSpinning = true;
    }

    public void StopSpin()
    {
        IsSpinning = false;
    }

    public void Tick(float deltaTime)
    {
        if (!IsSpinning)
            return;

        contentParent.anchoredPosition += Vector2.up * spinSpeed * deltaTime;

        if (Mathf.Abs(contentParent.anchoredPosition.y) >= symbolHeight)
        {
            contentParent.anchoredPosition += Vector2.down * symbolHeight;

            recycleAction?.Invoke();
        }
    }
}
