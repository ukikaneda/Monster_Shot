using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
   public void OnClickStartButton()
    {
        SceneManager.LoadScene("MonsterShotMain");
    }
}
