using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string sceneToLoad;
    public void OnTriggerEnter2D(Collider2D other){
        //Calls the PlatformerPlayer script
        PlatformerPlayer player = other.GetComponent<PlatformerPlayer>();

        //Detects if player is touching the object.
        if (player != null){
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
