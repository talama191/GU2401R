using System.Collections.Generic;
using UnityEngine;

public class BuilderPanel : MonoSingleton<BuilderPanel>
{
    [SerializeField] GameObject panel;
    [SerializeField] TowerBuildInfo buildInfoPrefab;
    [SerializeField] Transform buildInfosContainer;

    private bool hasSetupBuildTowerBtn;
    private List<TowerBuildInfo> buildInfos = new List<TowerBuildInfo>();
    private bool isOpening = false;

    private void InitSetup()
    {
        if (hasSetupBuildTowerBtn) return;
        hasSetupBuildTowerBtn = true;
        var towers = ResourceManager.Instance.TowerDatas;
        foreach (var towerData in towers)
        {
            TowerBuildInfo buildInfoUI = Instantiate(buildInfoPrefab, buildInfosContainer);
            buildInfoUI.Setup(towerData);
            buildInfos.Add(buildInfoUI);
        }
    }

    public void OpenPanel(Node node)
    {
        if (isOpening) return;
        isOpening = true;
        panel.SetActive(true);
        InitSetup();
        foreach (var buildInfo in buildInfos)
        {
            buildInfo.SetupNode(node);
        }
        var worldPos = node.Position;
        var screenPos = Camera.main.WorldToScreenPoint(worldPos);
        panel.transform.position = screenPos;
    }

    public void ClosePanel()
    {
        isOpening = false;
        panel.SetActive(false);
    }
}
