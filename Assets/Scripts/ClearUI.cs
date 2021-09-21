using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class ClearUI : MonoBehaviour
{
    [SerializeField] GameObject ScreenText;
    [SerializeField] GameObject TitleButton;

    void Start()
    {
        Invoke("ClearSceneScreenText", 4.515f);
        Invoke("ClearSceneTitleButton", 5.4f);

    }

    public void ClearSceneScreenText()
    {
        ScreenText.SetActive(true);
    }
    public void ClearSceneTitleButton()
    {
        TitleButton.SetActive(true);
    }
    public void OnClickButton()
    {
        
        SceneManager.LoadScene("TitleScene");

    }

}
