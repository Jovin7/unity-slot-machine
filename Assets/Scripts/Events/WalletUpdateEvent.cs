using System.Collections;
using UnityEngine;


    public struct WalletUpdateEvent :IEvent
    {

       public int coin;

        public WalletUpdateEvent (int coin)
        {
            this.coin = coin;
          
        }
    }
