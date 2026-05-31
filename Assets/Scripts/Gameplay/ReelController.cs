using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelController : MonoBehaviour, IReel
{
    private IReelSpinner reelSpinner;
    private IReelStopper reelStopper;
    private IReelSymbolTracker symbolTracker;
    private IReelGenerator reelGenerator;
    [Header("Setup")]
    private SymbolDatabase database;
    private SymbolView symbolPrefab;
    private RectTransform contentParent;


    [Header("Reel Settings")]
    private int visibleSymbols = 4;
    public int totalSymbols = 8;
    private List<SymbolView> currentSymbols = new();

    [Header("Spin Settings")]
    public float spinSpeed = 2000f;
    [SerializeField] float acceleration = 6000f;
    [SerializeField] float deceleration = 5000f;
    public float symbolHeight = 150f;

    [SerializeField]
    private float stopLerpSpeed = 10f;
    private float spinTimer;
    public float spinDuration = 1f;


    private void Start()
    {
        contentParent = this.GetComponent<RectTransform>();
        reelSpinner = new ReelSpinner(contentParent, spinSpeed, symbolHeight, RecycleSymbol);
        reelStopper = new ReelStopper(contentParent, symbolHeight, stopLerpSpeed, OnStopComplete);
        symbolTracker = new ReelSymbolTracker(currentSymbols);
    }
    private void Update()
    {

        if (reelSpinner.IsSpinning)
        {
            reelSpinner.Tick(Time.deltaTime);

            spinTimer += Time.deltaTime;

            if (spinTimer >= spinDuration)
            {
                StopSpin();
            }
        }
        reelStopper.Tick(Time.deltaTime);
    }
    public void StartSpin()
    {
        reelSpinner.StartSpin();
        spinTimer = 0f;
    }

    public void StopSpin()
    {
        reelSpinner.StopSpin();
        reelStopper.StartStop();
    }


    public void RecycleSymbol()
    {
        Transform top = contentParent.GetChild(0);

        top.SetAsLastSibling();

        SymbolView newsymbol = top.GetComponent<SymbolView>();

        newsymbol.Setup(RNGService.GetWeightedSymbol(database));
        symbolTracker.Recycle(newsymbol);
    }
   

    private void OnStopComplete()
    {
        EventBus.Publish(new ReelStoppedEvent());
    }
    public void Intialize(SymbolDatabase data, SymbolView prefab)
    {
        database = data;
        symbolPrefab = prefab;

        reelGenerator = new ReelGenerator(database, symbolPrefab, transform, visibleSymbols, currentSymbols);

        reelGenerator.Generate();
    }
    public SymbolData[] GetVisibleSymbolData()
    {
        return symbolTracker.GetVisibleData();
    }

    public SymbolView GetSymbolAtRow(int row)
    {
        return symbolTracker.GetSymbolAtRow(row);
    }

    public void UpdateSymbolAtRow(int row, SymbolData data)
    {
        symbolTracker.UpdateSymbolAtRow(row, data);
    }
}
