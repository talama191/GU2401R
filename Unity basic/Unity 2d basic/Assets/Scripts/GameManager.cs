using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private UIController uiController;

    public UIController UIController => uiController;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
