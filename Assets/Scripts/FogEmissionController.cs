using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogEmissionController : MonoBehaviour
{
   ParticleSystem.EmissionModule emimob;
   
   void Start () 
   {
        //↓Cube の 子オブジェクトである"Particle1"オブジェクトから ParticleSystemコンポーネントを取得 
        ParticleSystem ParticleObj = transform.Find("GroundFog").GetComponent<ParticleSystem>();
        //↓最終目的である rate にアクセスするために必要な emission を取得し格納
        emimob = ParticleObj.emission;
    }

 

    private float mCount = 0;       //←時間計測用
    private bool mSwitch = true;    //←切り替えスイッチ用
    void Update()
    {
        mCount = mCount + Time.deltaTime;   //←時間計測中
        if (mCount >= 8.0f) 
        { //← 5秒経過する度に if 成立
            mCount = 0; // 時間計測用変数を初期化
            if (mSwitch == true) 
            {
                //↓Rate を 1 に変更
                emimob.rate = new ParticleSystem.MinMaxCurve(1);
            } 
            else 
            {
                //↓Rate を 25 に変更
                emimob.rate = new ParticleSystem.MinMaxCurve(25);
            }

　　　　　//↓ true が false に、false が true に交互に入れ替わり続ける
            mSwitch = !mSwitch;
        }

    }
}