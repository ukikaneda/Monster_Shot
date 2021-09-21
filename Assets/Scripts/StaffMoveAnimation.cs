using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffMoveAnimation : MonoBehaviour
{
    private Animator staffAnim;
    private float timeBetweenShot = 0.5f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        staffAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && timer > timeBetweenShot)
        {
            timer = 0.0f;
            staffAnim.SetTrigger("staffAction");

        }
    }
}
