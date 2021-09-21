using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitController : MonoBehaviour
{
    public GameObject breakEffect;

    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();  
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        //衝突したオブジェクトがPlasmaだったとき
        if (collision.gameObject.CompareTag("Plasma"))
        {
            animator.SetBool("death", true);
            GetComponent<AudioSource>().Play();

            GenerateEffect();
            //敵(スクリプトがアタッチされているオブジェクト自身)を削除
            Destroy(this.gameObject, 1.3f);
            //Plasma(引数オブジェクト)を削除
            Destroy(collision.gameObject, 1.3f);

        }
    }
    //エフェクトを生成する
    void GenerateEffect()
    {
        //エフェクトを生成する
        GameObject effect = Instantiate(breakEffect) as GameObject;
        //エフェクトが発生する場所を決定する（敵オブジェクトの場所）
        effect.transform.position = gameObject.transform.position;
        
    }

}
