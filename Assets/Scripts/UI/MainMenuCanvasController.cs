using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class MainMenuController : MonoBehaviour
{

    [SerializeField] private Button PlayButton;
    [SerializeField] private TextMeshProUGUI cointText;
    [SerializeField] private TextMeshProUGUI experienceText;
    [SerializeField] private Transform gamePanel;
    [SerializeField] private Transform gameScreen;


    void Start()
    {

    }
    private void OnEnable()
    {
        PlayButton.onClick.AddListener(OnPlayButtonClicked);
        EventBus.Subscribe<WalletUpdateEvent>(OnCoinsUpdated);
    }
    private void OnDisable()
    {
        PlayButton.onClick.RemoveListener(OnPlayButtonClicked);
        EventBus.UnSubscribe<WalletUpdateEvent>(OnCoinsUpdated);
    }

    
    public void OnPlayButtonClicked()
    {
        gameScreen.gameObject.SetActive(true);
        gamePanel.gameObject.SetActive(false);
        EventBus.Publish(new PlayButtonClickedEvent());
    }

 
    private void OnCoinsUpdated(WalletUpdateEvent obj)
    {
        cointText.text = obj.coin.ToString();
    }



}
