using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public MainMenuController mainScreen;
    public GameCanvasController gameScreen;

    public ReelController[] reels;
    public SymbolView symbolPrefab;

    [Header("Data")]
    public PaylineDatabase paylineDatabase;
    public SymbolDatabase reelDatabases;

    private IGameStateMachine StateMachine;

    public IGameState IdleState { get; private set; }
    public IGameState SpinState { get; private set; }
    public IGameState ResultState { get; private set; }
    public IGameState WinState { get; private set; }

    private IWalletService walletService;
    private ISpinService spinService;
    private IPaylineService paylineService;
    private ISymbolMatcher symbolMatcher;
    private IGridModifier gridModifier;
    private IWinPresentationService winPresentationService;

    private GameSessionContext sessionContext;
    public PaylineRenderer paylineRenderer;
    private int stoppedReelsCount = 0;


    void Awake()
    {
        sessionContext = new GameSessionContext();
        spinService = new SpinService(reels);
        symbolMatcher = new StandardSymbolMatcher();
        gridModifier = new ExpandingWildModifier();
        paylineService = new PaylineService(reels, paylineDatabase, symbolMatcher, gridModifier, sessionContext);
        winPresentationService = new WinPresentationService(reels, paylineRenderer);
        walletService = new WalletService();
        
        StateMachine = new GameStateMachine();
        IdleState = new IdleState();
        WinState = new WinState(StateMachine, IdleState, winPresentationService, sessionContext);
        ResultState = new ResultState(StateMachine, IdleState, WinState, paylineService, sessionContext);
        SpinState = new SpinState(spinService, StateMachine,ResultState);
        

    }
    private void OnEnable()
    {
        EventBus.Subscribe<PlayButtonClickedEvent>(PlayButtonClicked);
        EventBus.Subscribe<SpinRequestedEvent >(RequestSpin);
        EventBus.Subscribe<ReelStoppedEvent>(OnReelStopped);
        EventBus.Subscribe<WinCalculatedEvent>(AddPlayerCoins);
    }

    private void OnDisable()
    {
        EventBus.UnSubscribe<PlayButtonClickedEvent>(PlayButtonClicked);
        EventBus.UnSubscribe<SpinRequestedEvent>(RequestSpin);
        EventBus.UnSubscribe<ReelStoppedEvent>(OnReelStopped);
        EventBus.UnSubscribe<WinCalculatedEvent>(AddPlayerCoins);
    }

    private void Start()
    {
        walletService.AddCoins(10000);

    }
   
    void Update()
    {
        if (StateMachine.currentState == null) return;

        StateMachine.Update();
    }

    private void PlayButtonClicked(PlayButtonClickedEvent obj)
    {
        ReelsInitialize();
    }
    public void ChangeState(IGameState newState)
    {
        StateMachine.ChangeState(newState);
    }

    public void RequestSpin(SpinRequestedEvent obj)
    {
        if (StateMachine.currentState is IdleState)
        {
            sessionContext.CurrentBet = obj.betAmount;
            walletService.SpendCoins(obj.betAmount);
            StateMachine.ChangeState(SpinState);
        }
    }
    public void ReelsInitialize()
    {
        foreach (var reel in reels)
        {
            reel.Intialize(reelDatabases, symbolPrefab);
        }
        StateMachine.Initialize(IdleState);

    }
   
   // -------------
    public void OnReelStopped(ReelStoppedEvent obj)
    {
       stoppedReelsCount ++;
        AudioManager.OnReelStop?.Invoke();
        if (stoppedReelsCount >= 5)
        {
            EventBus.Publish(new AllReelsStoppedEvent());
            stoppedReelsCount = 0;
        }
    }
   
    private void AddPlayerCoins(WinCalculatedEvent obj)
    {
        walletService.AddCoins(obj.result.totalPayout);

    }
   

}
