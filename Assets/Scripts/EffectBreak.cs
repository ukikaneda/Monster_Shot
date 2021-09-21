﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBreak : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //エフェクトが生成されて2秒後にオブジェクトを削除する
        Invoke("BreakEffect", 1.0f);

    }

    //エフェクト（自分自身）を削除する
    void BreakEffect()
    {
        Destroy(this.gameObject);
    }
}
