using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlasmaBreak : MonoBehaviour
{ 
    //オブジェクトの寿命
    [SerializeField] float lifetime = 3f;
    public GameObject plasmaBreakEffect;

    void Start()
    {
        //一定時間経過後にオブジェクトを破壊する
        Destroy(gameObject, lifetime);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag ("Enemy"))
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag ("Target"))
        {
            GenerateEffect();
    
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag ("Ground"))
        {
            GenerateEffect();

            Destroy(this.gameObject);
        }
    }
      void PlasmaBreakEffect()
    {
        Destroy(this.gameObject);
    }
        //エフェクトを生成する
    void GenerateEffect()
    {
        //エフェクトを生成する
        GameObject effect = Instantiate(plasmaBreakEffect) as GameObject;
        //エフェクトが発生する場所を決定する（敵オブジェクトの場所）
        effect.transform.position = gameObject.transform.position;
        
    }
}
