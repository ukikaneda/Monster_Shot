using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButttonSEController : MonoBehaviour
{
     private AudioSource ButtonSE;
  // Use this for initialization
    void Start () 
    {
        ButtonSE = GetComponent<AudioSource>();
        //画面遷移してもオブジェクトが壊れないようにする
        DontDestroyOnLoad (this);
 
    }
    public void OnClickButton()
    {
        ButtonSE.PlayOneShot(ButtonSE.clip);
    }
 
}
