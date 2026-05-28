using System.Collections;
using UnityEngine;

public interface IWalletService
{
    int Coins { get; }
 

    void AddCoins(int amount);
   

    bool SpendCoins(int amount);
    
}