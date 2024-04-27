using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuPopup : MonoBehaviour
{
    private static readonly string[] LevelNames = { "Level1", "Level2" };

    [SerializeField] private Button playLevelButtonPrefab;
    [SerializeField] private Transform buttonContainer;

    private void Awake()
    {
        foreach (var levelName in LevelNames)
        {
            Button button = Instantiate(playLevelButtonPrefab, buttonContainer);
            button.GetComponentInChildren<TextMeshProUGUI>().text = levelName;
            button.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(levelName);
            });
        }
    }
}
