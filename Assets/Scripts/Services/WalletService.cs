using System.Collections;
using UnityEngine;

public class WalletService : IWalletService
{
    public int Coins { get; private set; }
   

    public void AddCoins(int amount)
    {
        Coins += amount;
        EventBus.Publish(new WalletUpdateEvent(Coins));
    }

  
    public bool SpendCoins(int amount)
    {
        if (Coins < amount)
            return false;

        Coins -= amount;
        EventBus.Publish(new WalletUpdateEvent(Coins));

        return true;
    }

  
}
