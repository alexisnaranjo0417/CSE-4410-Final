using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public GameObject player;
    public Transform respawn;

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Player")){
            //SceneManager.LoadScene("V0");
            if (Coins.Instance.GetCoinCount() > 0)
            {
                Coins.Instance.AddCoin(-1);
            }
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
            //player.transform.position = respawn.position;
        }
    }
}
