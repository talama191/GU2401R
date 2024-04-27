using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoUIManager : MonoBehaviour
{
    public static PlayerInfoUIManager Instance { get; private set; }

    [SerializeField] Slider hpSlider;
    [SerializeField] TextMeshProUGUI hpText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateHP(float hp, float maxHp)
    {
        hpSlider.value = hp / maxHp;
        hpText.text = $"{hp}/{maxHp}";
    }
}
