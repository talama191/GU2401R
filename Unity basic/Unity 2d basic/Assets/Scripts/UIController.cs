using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private List<PopupBase> popups;
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

    public void OpenShopPopup()
    {
        foreach (var popup in popups)
        {
            if (popup is ShopPopup)
            {
                popup.Open();
                return;
            }
        }
    }
}
