using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        PlayerData.Instance.SaveScore(); // After Exit update
        Application.Quit();
    }
}