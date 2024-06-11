using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    int score;

    private void Awake()
    {
        LoadData();
        SetScoreText();
    }

    public void IncreaseScore()
    {
        score++;
        SaveData();
        SetScoreText();
    }

    private void SetScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("score", score);
    }

    private void LoadData()
    {
        score = PlayerPrefs.GetInt("score", 100);
    }
}
