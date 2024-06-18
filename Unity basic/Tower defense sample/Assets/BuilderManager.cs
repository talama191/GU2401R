using UnityEngine;
public class BuilderManager : MonoBehaviour
{
    [SerializeField] private BasicTower towerPrefab;

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
            if (buildableBase != null)
            {
                bool canBuild = GameBoard.Instance.RemoveNode(node);
                if (canBuild)
                {
                    BasicTower tower = Instantiate(towerPrefab);
                    tower.transform.position = node.Position;
                }
            }
        }
    }
}
