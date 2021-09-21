using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ClearCamMove : MonoBehaviour
{
    void Start()
    {
        Invoke ("move",0.5f);
    }

    void move()
    {
        this.transform.DOMove(new Vector3(0, 0.05f, -1.4f), 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
