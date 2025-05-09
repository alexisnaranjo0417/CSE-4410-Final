using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        if (Coins.Instance != null)
        {
            Coins.Instance.ResetCoins();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame(){
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}
