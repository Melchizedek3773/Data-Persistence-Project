using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    public Text BestScoreText;

    void Awake()
    {
        PlayerData.Instance.LoadScore();
        BestScore();
    }

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void BestScore()
    {
        BestScoreText.text = "Best score: " + PlayerData.Instance.Name + " " + PlayerData.Instance.Scores;
    }


    public void Exit()
    {
        PlayerData.Instance.SaveScore(); // After Exit update\
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}