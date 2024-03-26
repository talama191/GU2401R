using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI scoreText;

    private float score = 0;

    public void AddScore(int score)
    {
        this.score += score;
        scoreText.text = this.score.ToString();
    }

    public void UpdateHpUI()
    {
        slider.value = PlayerController.Instance.CurrentHp / PlayerController.Instance.MaxHp;
    }
}
