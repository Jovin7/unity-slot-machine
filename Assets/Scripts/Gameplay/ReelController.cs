using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelController : MonoBehaviour
{
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

    private bool isStopping;

    [SerializeField]
    private float stopLerpSpeed = 10f;
    public bool IsSpinning { get; private set; }
    private float spinTimer;
    public float spinDuration = 1f;
    public bool IsBusy => IsSpinning || isStopping;

    private void Start()
    {
        contentParent = this.GetComponent<RectTransform>();
    }
    private void Update()
    {
        
        if (IsSpinning)
        {
            Spin();

            spinTimer += Time.deltaTime;

            if (spinTimer >= spinDuration)
            {
                StopSpin();
            }
        }

        if (isStopping)
        {
            SmoothStop();
        }
    }
    void Spin()
    {
        contentParent.anchoredPosition += Vector2.up * spinSpeed * Time.deltaTime;

        if (Mathf.Abs(contentParent.anchoredPosition.y) >= symbolHeight)
        {
            contentParent.anchoredPosition += Vector2.down * symbolHeight;

            RecycleSymbol();
        }
    }

    void RecycleSymbol()
    {
        Transform top = contentParent.GetChild(0);

        top.SetAsLastSibling();

        SymbolView newsymbol = top.GetComponent<SymbolView>();

        newsymbol.Setup(RNGService.GetWeightedSymbol(database));
        UpdateVisibleData(newsymbol);
    }
    public void UpdateVisibleData(SymbolView newsymbol)
    {
        currentSymbols.RemoveAt(0);
        currentSymbols.Add(newsymbol);
        
    }
    public void StartSpin()
    {
        IsSpinning = true;
        spinTimer = 0f;
    }

    public void StopSpin()
    {
        IsSpinning = false;
        isStopping = true;
    }
    void SmoothStop()
    {
        float currentY = contentParent.anchoredPosition.y;

        float targetY = Mathf.Floor(currentY / symbolHeight) * symbolHeight;

        float newY = Mathf.Lerp(currentY, targetY, stopLerpSpeed * Time.deltaTime);

        contentParent.anchoredPosition = new Vector2(contentParent.anchoredPosition.x, newY);

        if (Mathf.Abs(newY - targetY) < 1f)
        {
            contentParent.anchoredPosition = new Vector2(contentParent.anchoredPosition.x, targetY);

            isStopping = false;
            EventBus.Publish(new ReelStoppedEvent());
        }
    }

    public void Intialize(SymbolDatabase data, SymbolView prefab )
    {
        database = data;
        symbolPrefab = prefab;
        GenerateReel();
    }
  
    public void GenerateReel()
    {
        ClearReel();
        for (int i =0;i< visibleSymbols;i++)
        {
            SymbolData randomSymbol = RNGService.GetWeightedSymbol(database);
            SymbolView symbol = Instantiate(symbolPrefab, this.transform);
            symbol.Setup(randomSymbol);
            currentSymbols.Add(symbol);
        }
    }
    void ClearReel()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        currentSymbols.Clear();
    }
    

    public SymbolData[] GetVisibleSymbolData()
    {
        SymbolData[] result = new SymbolData[visibleSymbols];

        for(int i =0;i< visibleSymbols;i++)
        {      
            result[i] = currentSymbols[i].GetData();
            //GameLogger.Reel(contentParent.name + "   " + result[i].symbolId);
        }
        return result;
    }
    public SymbolView GetSymbolAtRow(int row)
    {
        return currentSymbols[row];
    }

}
