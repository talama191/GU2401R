using System.Collections.Generic;
using UnityEngine;
public class BuilderManager : MonoSingleton<BuilderManager>
{
    private List<TowerData> towerDatas;

    private void Start()
    {
        towerDatas = ResourceManager.Instance.TowerDatas;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastBuildableBase();
        }
    }

    private void RaycastBuildableBase()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        var hit = Physics.Raycast(ray, out hitInfo, float.PositiveInfinity, LayerMask.GetMask("RaycastOnly"));
        if (hit)
        {
            BuildableBase buildableBase = hitInfo.collider.GetComponent<BuildableBase>();
            Node node = hitInfo.collider.GetComponent<Node>();

            Node checkNode = GameBoard.Instance.GetNode(node.X, node.Z);
            if (checkNode == null) return;
            if (buildableBase != null)
            {
                bool canBuild = GameBoard.Instance.CheckNodeBuildable(node);
                if (canBuild)
                {
                    //bat menu xay tru
                    BuilderPanel.Instance.OpenPanel(node);
                }
            }
        }
    }

    public void BuildTower(Node node, TowerData data)
    {
        BasicTower tower = Instantiate(data.TowerPrefab);
        tower.Setup(data);
        tower.transform.position = node.Position;
        GameBoard.Instance.RemoveNode(node);
    }
}
