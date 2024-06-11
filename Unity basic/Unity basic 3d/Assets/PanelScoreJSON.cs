using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
public class PanelScoreJSON : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI inputPlayerNameText;
    [SerializeField] private TextMeshProUGUI playerNameText;

    private string filePath;
    private Player player;

    void Awake()
    {
        filePath = Application.persistentDataPath + "/player.json";
    }

    private void Start()
    {
        Load();
        RefreshUI();
    }

    private void RefreshUI()
    {
        playerNameText.text = "Player Name:" + player.PlayerName;
        scoreText.text = "Score: " + player.Score;
    }

    public void IncreaseScore()
    {
        player.Score++;
        Save();
        RefreshUI();
    }

    public void SetPlayerName()
    {
        player.PlayerName = inputPlayerNameText.text;
        Save();
        RefreshUI();
    }

    private void Save()
    {
        string json = JsonUtility.ToJson(player);
        File.WriteAllText(filePath, json);
    }

    private void Load()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            player = JsonUtility.FromJson<Player>(json);
            return;
        }
        player = new Player("Nam", 0, new Vector3[] { Vector3.zero, Vector3.one, Vector3.one * 1.35f });
        Save();
    }
}

[System.Serializable]
public class Player
{
    public string PlayerName;
    public int Score;
    public Vector3[] Positions;

    public Player(string playerName, int score, Vector3[] positions)
    {
        this.PlayerName = playerName;
        this.Score = score;
        this.Positions = positions;
    }
}