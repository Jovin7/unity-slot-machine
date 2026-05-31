using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameCanvasController : MonoBehaviour
{

    [SerializeField] private Button spinButton;
    [SerializeField] private Button increment;
    [SerializeField] private Button decrement;
    [SerializeField] private TextMeshProUGUI betAmount;
    [SerializeField] private TextMeshProUGUI winAmount;

    private int currentBet = 1;
    private int minBet = 1;
    private int maxBet = 50000;

    private void Start()
    {
        currentBet = 100;
        UpdateBetUI();
    }
    private void OnEnable()
    {
        spinButton.onClick.AddListener(OnSpinClick);
        increment.onClick.AddListener(IncreaseBet);
        decrement.onClick.AddListener(DecreaseBet);
        EventBus.Subscribe<SpinAvailabilityChangedEvent>(SetSpinButton);
        EventBus.Subscribe<WinCalculatedEvent>(UpdateWinAmountUI);

    }

    private void OnDisable()
    {
        spinButton.onClick.RemoveListener(OnSpinClick);
        increment.onClick.RemoveListener(IncreaseBet);
        decrement.onClick.RemoveListener(DecreaseBet);
        EventBus.UnSubscribe<SpinAvailabilityChangedEvent>(SetSpinButton);
        EventBus.UnSubscribe<WinCalculatedEvent>(UpdateWinAmountUI);
    }


    public void OnSpinClick()
    {
        spinButton.interactable = false;
        EventBus.Publish(new SpinRequestedEvent(currentBet));
    }
    private void SetSpinButton(SpinAvailabilityChangedEvent obj)
    {
        spinButton.interactable = true;
    }
    private void IncreaseBet()
    {
        if (currentBet >= maxBet)
            return;

        currentBet++;

        UpdateBetUI();
    }

    private void DecreaseBet()
    {
        if (currentBet <= minBet)
            return;

        currentBet--;

        UpdateBetUI();
    }
    private void UpdateBetUI()
    {
        betAmount.text = currentBet.ToString();
    }
    private void UpdateWinAmountUI(WinCalculatedEvent obj)
    {
        winAmount.text = obj.result.totalPayout.ToString();
    }

}
