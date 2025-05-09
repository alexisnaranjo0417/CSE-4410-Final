using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public static Coins Instance;

    public int TotalCoins { get; private set; } = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCoin(int amount)
    {
        TotalCoins += amount;
        Messenger.Broadcast(GameEvent.COIN_PICKUP);
    }

    public void ResetCoins()
    {
        TotalCoins = 0;
    }
    
    public int GetCoinCount()
    {
        return TotalCoins;
    }
}
