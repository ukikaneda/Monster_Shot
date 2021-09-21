using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCharaMoveF : MonoBehaviour
{
    int counter = 0;
    float move0 = 0.0002f;

    IEnumerator Start () 
    {
        enabled = false;
		yield return new WaitForSeconds (9f);
		enabled = true;
    }
 
    void FixedUpdate()
    {
        Vector3 position = new Vector3(move0, 0, 0);
        transform.Translate(position);
        counter++;
        if (counter == 840)
        {
           counter = 0;
           transform.Rotate(new Vector3(0, 180, 0));
        }
    }
}
