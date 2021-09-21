using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieUp : MonoBehaviour 
{

    private float moveUpDistance = 0.07f; // 移動させる距離
    private float moveUpedDistance = 0f; // 移動した距離
    private float moveUpSpeed = 0.0005f; // 移動させる速さ
    private GameObject target;
    private Animator animator;
    [SerializeField] float walkspeed;
    public GameObject moveObject; 
    bool isgrounded = false;

    void Start ()
    {
        animator = GetComponent<Animator>();
        var rb = GetComponent<Rigidbody>();
    }
    void Update () 
    {
        if (isgrounded == false)
        {
            transform.position += transform.up * moveUpSpeed;
            moveUpedDistance += moveUpSpeed;
        }    
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ground") 
        {
            isgrounded = true;
        }
    }
    void FixedUpdate()
    {
        if (isgrounded == true)
        {
            target = GameObject.Find("Egg");
            transform.LookAt(target.transform);
            animator.SetBool("walk", true);
            transform.position += transform.forward * walkspeed;
        }
    }
    IEnumerator OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.CompareTag ("Target"))
        {
            yield return new WaitForSeconds (1.0f);
            SceneManager.LoadScene("GameOver");
        }
    }
}