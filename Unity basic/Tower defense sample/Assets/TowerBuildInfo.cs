using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class TowerBuildInfo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] Image icon;

    private TowerData towerData;
    private Node node;

    public void Setup(TowerData data)
    {
        this.towerData = data;

        nameText.text = data.TowerName;
        icon.sprite = data.Icon;
    }

    public void SetupNode(Node node)
    {
        this.node = node;
    }

    public void BuildTower()
    {
        BuilderManager.Instance.BuildTower(node, towerData);
        BuilderPanel.Instance.ClosePanel();
    }
}
