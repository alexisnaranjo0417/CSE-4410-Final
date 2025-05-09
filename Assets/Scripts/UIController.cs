using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text coinLabel;
    [SerializeField] TMP_Text timerLabel;
    [SerializeField] SettingsPopup settingsPopup;

    private int coin;
    private float startTime;

    private void OnEnable()
    {
        Messenger.AddListener(GameEvent.COIN_PICKUP, CoinPickup);
    }

    private void OnDisable()
    {
        Messenger.RemoveListener(GameEvent.COIN_PICKUP, CoinPickup);
    }

    private void CoinPickup()
    {
        coin += 1;
        coinLabel.text = "Coins: " + Coins.Instance.TotalCoins.ToString();
    }

    private void Start()
    {
        coin = 0;
        coinLabel.text = "Coins: " + Coins.Instance.TotalCoins.ToString();

        startTime = Time.realtimeSinceStartup;

        settingsPopup.Close();
    }

    // Update is called once per frame
    void Update()
    {
        float timeSinceStart = Time.realtimeSinceStartup - startTime;
        timerLabel.text = "Timer: " +  timeSinceStart.ToString("F2");
    }

    public void OnOpenSettings()
    {
        // Debug.Log("Opening settings...");
        settingsPopup.Open();
    }
}
