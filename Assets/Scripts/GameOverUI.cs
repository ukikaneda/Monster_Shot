using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{

    [SerializeField] GameObject ScreenColor;
    [SerializeField] GameObject ScreenText;
    [SerializeField] GameObject RetryButton;
    [SerializeField] GameObject TitleButton;


    void Start()
    {
        Invoke("EndSceneScreenColor", 2.9f);
        Invoke("EndSceneScreenText", 3.6f);
        Invoke("EndSceneTitleButton", 5f);
        Invoke("EndSceneRetryButton", 5f);
    }

    public void EndSceneScreenColor()
    {
        ScreenColor.SetActive(true);
    }

    public void EndSceneScreenText()
    {
        ScreenText.SetActive(true);
    }
    public void EndSceneTitleButton()
    {
        TitleButton.SetActive(true);
    }
    public void OnClickTitleButton()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void EndSceneRetryButton()
    {
        RetryButton.SetActive(true);
    }
    public void OnClickRetryButton()
    {
        SceneManager.LoadScene("MonsterShotMain");
    }
}
