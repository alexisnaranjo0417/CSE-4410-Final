using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic instance;

    private void Awake(){
        if(instance == null){
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }
}
