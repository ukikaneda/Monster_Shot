using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ClearChickMove6 : MonoBehaviour
{
    int counter = 0;
    float move = 0.002f;
 
    void Update()
    {
        Vector3 position = new Vector3(0, 0, move);
        transform.Translate(position);
        counter++;
        if (counter == 120)
        {
           counter = 0;
           transform.Rotate(new Vector3(0, 180, 0));
        }
    }
}