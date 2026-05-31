using System;
using System.Collections;
using UnityEngine;


public class ReelStopper : IReelStopper
{
    private RectTransform contentParent;
    private float symbolHeight;
    private float stopLerpSpeed;
    private Action stopCompleteAction;
    public bool IsStopping { get; private set; }
    public ReelStopper(RectTransform contentParent, float symbolHeight, float stopLerpSpeed, Action stopCompleteAction)
    {
        this.contentParent = contentParent;
        this.symbolHeight = symbolHeight;
        this.stopLerpSpeed = stopLerpSpeed;
        this.stopCompleteAction = stopCompleteAction;
    }

    public void StartStop()
    {
        IsStopping = true;
    }


    public void Tick(float deltaTime)
    {
        if (!IsStopping)
            return;

        float currentY = contentParent.anchoredPosition.y;

        float targetY = Mathf.Floor(currentY / symbolHeight) * symbolHeight;

        float newY = Mathf.Lerp(currentY, targetY, stopLerpSpeed * Time.deltaTime);

        contentParent.anchoredPosition = new Vector2(contentParent.anchoredPosition.x, newY);

        if (Mathf.Abs(newY - targetY) < 1f)
        {
            contentParent.anchoredPosition = new Vector2(contentParent.anchoredPosition.x, targetY);

            IsStopping = false;
            stopCompleteAction?.Invoke();
        }
    }
}
