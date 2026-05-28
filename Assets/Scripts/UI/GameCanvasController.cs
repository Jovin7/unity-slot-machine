using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvasController : MonoBehaviour
{
    
    [SerializeField] private Button spinButton;

    private void OnEnable()
    {
        spinButton.onClick.AddListener(OnSpinClick);

        EventBus.Subscribe<SpinAvailabilityChangedEvent>(SetSpinButton);
    }

    private void OnDisable()
    {
        spinButton.onClick.RemoveListener(OnSpinClick);
        EventBus.UnSubscribe<SpinAvailabilityChangedEvent>(SetSpinButton);
    }

    
    public void OnSpinClick()
    {
        spinButton.interactable = false;
        EventBus.Publish(new SpinRequestedEvent ());
    }
    private void SetSpinButton(SpinAvailabilityChangedEvent obj)
    {
        spinButton.interactable = true;
    }

}
