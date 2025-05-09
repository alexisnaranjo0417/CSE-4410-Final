using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip coinSound;

    private int coinAmount = 1;

    public void OnTriggerEnter2D(Collider2D other){
        //Calls the PlatformerPlayer script
        PlatformerPlayer player = other.GetComponent<PlatformerPlayer>();

        //Detects if player is touching the object.
        if (player != null){
            //Player earns the coin.
            Coins.Instance.AddCoin(coinAmount);
            audioSource.PlayOneShot(coinSound);
            //Destroys object/coin when picked up.
            Destroy(gameObject);
            Messenger.Broadcast(GameEvent.COIN_PICKUP);
            //Gets coin it prints this message.
            Debug.Log("Gained 1 Coin!");
        }
    }
}
