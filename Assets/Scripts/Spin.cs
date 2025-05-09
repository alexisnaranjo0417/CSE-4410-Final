using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    //Sets speed to 3
    public float speed = 3f;



    // Update is called once per frame
    void Update()
    {
        //Allows the object to rotate at a speed of 3 * (from last frame executed)
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}