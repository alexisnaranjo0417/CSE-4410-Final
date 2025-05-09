using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPopup : MonoBehaviour
{

//Opens the popup for settings
public void Open(){
    gameObject.SetActive(true);
}

//Closes the popup for settings
public void Close(){
    gameObject.SetActive(false);
}

    //Exits Game
public void ExitGame()
{
    Application.Quit();
    //UnityEditor.EditorApplication.isPlaying = false;
}
}