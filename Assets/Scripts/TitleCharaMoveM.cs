using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCharaMoveM : MonoBehaviour
{
   int counter = 0;
    float move0 = 0.0003f;
 
    void FixedUpdate()
    {
        Vector3 position = new Vector3(move0, 0, 0);
        transform.Translate(position);
        counter++;
        if (counter == 850)
        {
           counter = 0;
           transform.Rotate(new Vector3(0, 180, 0));
        }
    }
}
